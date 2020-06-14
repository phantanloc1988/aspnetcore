using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi10.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductModel
    {
        public int productID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double Quantity { get; set; }
    }
}
