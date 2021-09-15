using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoolServerApp.Service
{
    public interface IDepartmentService
    {
        IEnumerable<tblDepartment> GetAllDepartments();
        tblDepartment GetDepartment(long id);
        void insertDepartment(tblDepartment department);
        void UpdateDepartment(tblDepartment department);
        void DeleteDepartment(long id);
    }
}
