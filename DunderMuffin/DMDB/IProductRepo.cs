using System.Collections.Generic;
using DMDB.Models;

namespace DMDB
{
    /// <summary>
    /// Data access interface for DunderMuffin products
    /// </summary>
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        Product GetProductByName(string name);
        List<Product> GetAllProducts();
    }
}