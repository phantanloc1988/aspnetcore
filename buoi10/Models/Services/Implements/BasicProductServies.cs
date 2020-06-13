using buoi10.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace buoi10.Models.Services.Implements
{
    public class BasicProductServies : IProductService
    {
        public static List<Product> products = new List<Product>();
        
        public void AddProduct(Product sp)
        {
            products.Add(sp);
        }

        public void DeleteProduct(int masp)
        {
            //LINQ
            var sanpham = products.SingleOrDefault(x => x.productID == masp);

            if (sanpham != null)
            {
                products.Remove(sanpham);
            }
        }

        public Product FindByID(int productID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void UpdateProduct(Product sp)
        {
            throw new NotImplementedException();
        }
    }
}
