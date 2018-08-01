using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommEngineApi.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        public Categories Categories { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}