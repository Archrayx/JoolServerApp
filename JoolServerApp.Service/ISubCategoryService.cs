using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Data;

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
