using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToDo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace WhatToDo.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly PlacesContext _db;

        public PlacesController(PlacesContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Place>> GetPlacesAsync([FromQuery] string[] categories, int limit = 1, bool random = false)
        {
            IQueryable<Place> query = _db.Places;

            if(categories.Length > 0)
            {
                query = query.Where(p => p.PlaceCategories.Any(pc => categories.Contains(pc.Category.Name)));
            }

            query = query.Include(p => p.Address)
            .Include(p => p.OpeningHoursList)
            .Include(p => p.Images)
            .Include(p => p.Urls)
            .Include(p => p.Thumbnail)
            .Include(p => p.PlaceCategories).ThenInclude(pc => pc.Category);

            if (random)
            {
                query = query.OrderBy(p => Guid.NewGuid());
            }
            var res = await query.Take(limit).ToArrayAsync();

            //eliminate cycles inside many-to-many relationship for serialization
            foreach(var place in res)
            {
                foreach(var category in place.PlaceCategories)
                {
                    category.Place = null;
                    category.Category.PlaceCategories = null;
                }
            }
            return res;
        }
    }
}
