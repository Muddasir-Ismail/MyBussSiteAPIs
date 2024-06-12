using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Interfaces
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int id);
        public Product GetProductById(int id);
        public List<Product> GetAllProducts();
        public List<Product> GetAllProductsByCategoryId(int categoryId);
    }
}
