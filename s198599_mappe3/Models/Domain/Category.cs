using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models.Domain
{
    public class Category
    {
        
        public int CategoryID { get; set; }

        [Required]
        [RegularExpression("^[A-ZÆØÅa-zæøå.]{5,30}$",ErrorMessage ="Category Name must be between 5 and 30 characters. No digits")]
        public string CategoryName { get; set; }
    }
}