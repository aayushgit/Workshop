using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkshopManager.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public Product Product { get; set; }
    }
}