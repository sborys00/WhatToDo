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
        [DataType(DataType.Time)]
        public DateTime OpeningHour { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime ClosingHour { get; set; }
    }
}