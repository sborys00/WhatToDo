﻿using DataAccess.DataAccess;
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
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly PlacesContext _db;

        public PlacesController(PlacesContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Place>> GetPlacesAsync(int limit = 1)
        {
            return await _db.Places.Take(limit).ToArrayAsync();
        }
    }
}
