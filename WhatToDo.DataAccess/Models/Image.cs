using System.ComponentModel.DataAnnotations;

namespace WhatToDo.DataAccess.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Source { get; set; }
    }
}