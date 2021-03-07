using WhatToDo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class PlacesContext : DbContext
    {
        public PlacesContext(DbContextOptions options) : base(options) { }
           
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceCategory>().HasKey(pc => new { pc.PlaceId, pc.CategoryId });
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OpeningHours> OpeningHours { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<PlaceCategory> PlaceCategories { get; set; }
    }
}
