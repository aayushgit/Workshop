using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkshopManager.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Model No.")]
        public string ModelNo { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name = "Product Stock")]
        [Required]
        public int Stock { get; set; }

        [Display(Name = "Product Type")]
        public ProductType ProductTypeId { get; set; }
    }
}