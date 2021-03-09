using DataAccess.DataAccess;
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
    public class CategoriesController : ControllerBase
    {
        private readonly PlacesContext _db;

        public CategoriesController(PlacesContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }
    }
}
