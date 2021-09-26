using JoolServerApp.Data;
using JoolServerApp.Repo;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<tblCategory> categoryRepository;

        public CategoryService(IRepository<tblCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<tblCategory> GetAllCategories()
        {
            return categoryRepository.GetAll();
        }
        public tblCategory GetCategory(long id)
        {
            return categoryRepository.Get(id);

        }
        public void insertCategory(tblCategory category)
        {
            categoryRepository.Insert(category);
            categoryRepository.SaveChanges();
        }
        public void UpdateCategory(tblCategory category)
        {
            categoryRepository.Update(category);
            categoryRepository.SaveChanges();
        }

        public void DeleteCategory(long id)
        {
            tblCategory category = GetCategory(id);
            categoryRepository.Remove(category);
            categoryRepository.SaveChanges();
        }
    }
}
