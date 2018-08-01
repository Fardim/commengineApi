using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommEngineApi.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string CategoryName { get; set; }
    }
}