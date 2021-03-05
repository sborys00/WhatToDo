﻿using System.ComponentModel.DataAnnotations;

namespace WhatToDo.DataAccess.Models
{
    public class Adress
    {
        [Key]
        public int AdressId { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }
    }
}