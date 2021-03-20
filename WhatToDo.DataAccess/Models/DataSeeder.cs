using DataAccess.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WhatToDo.DataAccess.Models
{
    public class DataSeeder
    {
        private readonly IServiceProvider _sr;
        private readonly PlacesContext _db;

        public DataSeeder (IServiceProvider serviceProvider)
        {
            _sr = serviceProvider;
        }

        public void SeedData(string path, string categoriesPath)
        {
            using (var serviceScope = _sr.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetRequiredService<PlacesContext>();
                if (!db.Places.Any())
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string json = sr.ReadToEnd();
                        
                        List<Place> places = JsonSerializer.Deserialize<List<Place>>(json);
                        using(StreamReader sr2 = new StreamReader(categoriesPath))
                        {
                            string jsonCategories = sr2.ReadToEnd();
                            List<CategoryPlaces> cp = JsonSerializer.Deserialize<List<CategoryPlaces>>(jsonCategories);
                            foreach(var cat in cp)
                            {
                                Category category = new Category { Name = cat.Name };
                                foreach(var pla in cat.Places)
                                {
                                    Place p = places.Find(p => p.Name == pla);
                                    if (p.PlaceCategories == null)
                                        p.PlaceCategories = new List<PlaceCategory>();

                                    p.PlaceCategories.Add(new PlaceCategory { Place = p, Category = category });
                                }
                                if(cat.Places.Count() == 0)
                                {
                                    db.Categories.Add(category);
                                }
                            }

                            foreach(var place in places)
                            {
                                place.OpeningHoursList = FillMissingHours(place.OpeningHoursList);
                            }
                            db.AddRange(places);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        public List<OpeningHours> FillMissingHours(List<OpeningHours> hours)
        {
            List<OpeningHours> newHours = new();

            if (hours.Count == 0 || hours.Count == 1)
            {
                for (int i = 0; i < 7; i++)
                {
                    OpeningHours nh = new();
                    switch (hours.Count)
                    {
                        //If it's empty, fill all week as open 24/7
                        case 0:
                            {
                                nh.DayOfTheWeek = i;
                                nh.OpeningHour = DateTime.UnixEpoch;
                                nh.ClosingHour = DateTime.UnixEpoch.AddDays(1);
                            }
                            break;
                        //If there is only first day included, fill rest of the week with same hours
                        case 1:
                            {
                                nh.DayOfTheWeek = hours[0].DayOfTheWeek + i;
                                nh.OpeningHour = hours[0].OpeningHour;
                                nh.ClosingHour = hours[0].ClosingHour;
                            }
                            break;
                    }
                    newHours.Add(nh);
                }
                return newHours;
            }
            else
                newHours.Add(hours[0]);

            int lastDay = hours[0].DayOfTheWeek;

            //Fill skipped days
            for (int i = 1; i < hours.Count; i++)
            {
                if (hours[i].DayOfTheWeek != lastDay + 1)
                {
                    int skippedDays = hours[i].DayOfTheWeek - lastDay - 1;
                    for (int j = 0; j < skippedDays; j++)
                    {
                        OpeningHours nh = new();
                        nh.DayOfTheWeek = hours[i - 1].DayOfTheWeek + j + 1;
                        nh.OpeningHour = hours[i - 1].OpeningHour;
                        nh.ClosingHour = hours[i - 1].ClosingHour;
                        newHours.Add(nh);
                        lastDay++;
                    }
                }
                newHours.Add(hours[i]);
                lastDay++;
            }
            while (newHours.Count < 7)
            {
                OpeningHours nh = new();
                nh.DayOfTheWeek = newHours[^1].DayOfTheWeek + 1;
                nh.OpeningHour = newHours[^1].OpeningHour;
                nh.ClosingHour = newHours[^1].ClosingHour;

                newHours.Add(nh);
            }

            return newHours;
        }

        private class CategoryPlaces
        {
            public string Name { get; set; }
            public IEnumerable<string> Places { get; set; }
        }
    }
}
