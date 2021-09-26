using JoolServerApp.Data;
using JoolServerApp.Repo;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public class ProjectService : IProjectService
    {
        private IRepository<tblProject> projectRepository;

        public ProjectService(IRepository<tblProject> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public IEnumerable<tblProject> GetAllProjects()
        {
            return projectRepository.GetAll();
        }
        public tblProject GetProject(long id)
        {
            return projectRepository.Get(id);
        }
        public void insertProject(tblProject project)
        {
            projectRepository.Insert(project);
            projectRepository.SaveChanges();

        }
        public void UpdateProject(tblProject project)
        {
            projectRepository.Update(project);
            projectRepository.SaveChanges();

        }

        public void DeleteProject(long id)
        {
            tblProject project = GetProject(id);
            projectRepository.Remove(project);
            projectRepository.SaveChanges();
        }
    }
}
