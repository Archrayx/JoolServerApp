using JoolServerApp.Data;
using System.Collections.Generic;

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
