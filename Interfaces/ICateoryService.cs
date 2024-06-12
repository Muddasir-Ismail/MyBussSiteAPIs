using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Interfaces
{
    public interface ICateoryService
    {
        public Category AddCategory(Category category);
        public Category UpdateCategory(Category category);
        public bool DeleteCategory(int id);
        public Category GetCategoryById(int id);
        public List<Category> GetAllCategories();

    }
}
