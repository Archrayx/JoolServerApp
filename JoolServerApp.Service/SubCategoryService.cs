using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Repo;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public class SubCategoryService:ISubCategoryService
    {
        private IRepository<tblSubCategory> subCategoryRepository;
        public SubCategoryService(IRepository<tblSubCategory> subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }

        public void DeleteSubCategory(long id)
        {
            tblSubCategory subCategory = subCategoryRepository.Get(id);
            subCategoryRepository.Remove(subCategory);
            subCategoryRepository.SaveChanges();
        }

        public IEnumerable<tblSubCategory> GetAllSubCategories()
        {
            return subCategoryRepository.GetAll();
        }

        public tblSubCategory GetSubCategory(long id)
        {
            return subCategoryRepository.Get(id);
        }

        public void insertSubCategory(tblSubCategory subCategory)
        {
            subCategoryRepository.Insert(subCategory);
            subCategoryRepository.SaveChanges();

        }

        public void UpdateSubCategory(tblSubCategory subCategory)
        {
            subCategoryRepository.Update(subCategory);
            subCategoryRepository.SaveChanges();

        }
    }
}