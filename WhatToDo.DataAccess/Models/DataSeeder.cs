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
                            db.AddRange(places);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        private class CategoryPlaces
        {
            public string Name { get; set; }
            public IEnumerable<string> Places { get; set; }
        }
    }
}
