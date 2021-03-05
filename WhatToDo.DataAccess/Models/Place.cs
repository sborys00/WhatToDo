using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToDo.DataAccess.Models
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        [Required]
        public Adress Adress { get; set; }

        public List<OpeningHours> OpeningHoursList { get; set; }

        public List<Image> Images { get; set; }
        
        public List<Url> Urls { get; set; }

        public List<Category> Categories { get; set; }
    }
}
