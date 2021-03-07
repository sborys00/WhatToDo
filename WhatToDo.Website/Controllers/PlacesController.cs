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
        public async Task<IEnumerable<Place>> GetPlacesAsync(int limit = 1, bool random = false)
        {
            var query = _db.Places.Take(limit).Include(p => p.Address)
                .Include(p => p.OpeningHoursList)
                .Include(p => p.Images)
                .Include(p => p.Urls)
                //.Include(p => p.Categories)
                .Include(p => p.Thumbnail);

            if(random)
            {
                query.OrderBy(p => Guid.NewGuid());
            }

            return await query.ToArrayAsync();
        }
    }
}
