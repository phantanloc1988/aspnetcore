using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi10.Models.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product sp);

        void UpdateProduct(Product sp);

        void DeleteProduct(int productID);

        Product? FindByID(int productID);

        IEnumerable<Product> GetAll();
    }
}
