using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkshopManager.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte ServiceCharge { get; set; }
    }
}