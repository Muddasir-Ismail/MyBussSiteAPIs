using MyBussSiteAPIs.Context;
using MyBussSiteAPIs.Interfaces;
using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Services
{
    public class CategoryService : ICateoryService
    {
        private readonly dbContext _dbContext;
        public CategoryService(dbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public Category AddCategory(Category category)
        {
            var addCat = _dbContext.Add(category);
            _dbContext.SaveChanges();
            return addCat.Entity;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var deleteCat = _dbContext.categories.SingleOrDefault(s => s.CategoryId == id);
                if (deleteCat == null)
                {
                    throw new Exception("Category not found!");
                }
                else
                {
                    _dbContext.categories.Remove(deleteCat);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Category> GetAllCategories()
        {
            var list = _dbContext.categories.ToList();
            return list;
        }

        public Category GetCategoryById(int id)
        {
            var getCat = _dbContext.categories.SingleOrDefault(s => s.CategoryId == id);
            return getCat;
        }

        public Category UpdateCategory(Category category)
        {
            var updateCat = _dbContext.categories.Update(category);
            _dbContext.SaveChanges();
            return updateCat.Entity;
        }
    }
}
