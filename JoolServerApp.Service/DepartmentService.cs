using JoolServerApp.Data;
using JoolServerApp.Repo;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IRepository<tblDepartment> departmentRepository;

        public DepartmentService(IRepository<tblDepartment> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public void DeleteDepartment(long id)
        {
            tblDepartment department = departmentRepository.Get(id);
            departmentRepository.Remove(department);
            departmentRepository.SaveChanges();
        }

        public IEnumerable<tblDepartment> GetAllDepartments()
        {
            return departmentRepository.GetAll();
        }

        public tblDepartment GetDepartment(long id)
        {
            return departmentRepository.Get(id);
        }

        public void insertDepartment(tblDepartment department)
        {
            departmentRepository.Insert(department);
            departmentRepository.SaveChanges();
        }

        public void UpdateDepartment(tblDepartment department)
        {
            departmentRepository.Update(department);
            departmentRepository.SaveChanges();
        }
    }
}