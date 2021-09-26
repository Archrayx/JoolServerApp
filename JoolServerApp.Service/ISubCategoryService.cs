using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface ISubCategoryService
    {
        IEnumerable<tblSubCategory> GetAllSubCategories();
        tblSubCategory GetSubCategory(long id);
        void insertSubCategory(tblSubCategory subCategory);
        void UpdateSubCategory(tblSubCategory subCategory);
        void DeleteSubCategory(long id);
    }
}
