using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface ICategoryService
    {
        IEnumerable<tblCategory> GetAllCategories();
        tblCategory GetCategory(long id);
        void insertCategory(tblCategory productCategory);
        void UpdateCategory(tblCategory productCategory);
        void DeleteCategory(long id);
    }
}
