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

        public void SeedData(string path)
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
                        db.AddRange(places);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
