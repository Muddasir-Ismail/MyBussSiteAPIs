using MyBussSiteAPIs.Context;
using MyBussSiteAPIs.Interfaces;
using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Services
{
    public class ProductService : IProductService
    {
        private readonly dbContext _dbContext;
        public ProductService(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            var addpro = _dbContext.Add(product);
            _dbContext.SaveChanges();
            return addpro.Entity;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var deletepro = _dbContext.products.SingleOrDefault(s => s.ProductId == id);
                if(deletepro == null)
                {
                    throw new Exception("Product not found!");
                }
                else
                {
                    _dbContext.products.Remove(deletepro);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            var list = _dbContext.products.ToList();
            return list;
        }

        public List<Product> GetAllProductsByCategoryId(int categoryId)
        {
            var getCustId = _dbContext.products.Where(s => s.CategoryId == categoryId).ToList();
            return getCustId;
        }

        public Product GetProductById(int id)
        {
            var getProId = _dbContext.products.SingleOrDefault(s => s.ProductId == id);
            return getProId;
        }

        public Product UpdateProduct(Product product)
        {
            var updatepro = _dbContext.products.Update(product);
            _dbContext.SaveChanges();
            return updatepro.Entity;
        }
    }
}
