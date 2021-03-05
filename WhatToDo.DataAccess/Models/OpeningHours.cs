using System;
using System.ComponentModel.DataAnnotations;

namespace WhatToDo.DataAccess.Models
{
    public class OpeningHours
    {
        [Key]
        public int OpeningHoursId { get; set; }

        [Required]
        [Range(0, 6)]
        public int DayOfTheWeek { get; set; }

        [Required]
        public DateTime OpeningHour { get; set; }

        [Required]
        public DateTime ClosingHour { get; set; }
    }
}