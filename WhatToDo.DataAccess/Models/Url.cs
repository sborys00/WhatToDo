using System.ComponentModel.DataAnnotations;

namespace WhatToDo.DataAccess.Models
{
    public class Url
    {
        [Key]
        public int UrlId { get; set; }

        [Required]
        [MaxLength(500)]
        public string UrlAdress { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}