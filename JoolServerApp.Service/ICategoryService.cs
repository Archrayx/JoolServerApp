using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
