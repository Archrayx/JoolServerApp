using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface IProjectService
    {
        IEnumerable<tblProject> GetAllProjects();
        tblProject GetProject(long id);
        void insertProject(tblProject Project);
        void UpdateProject(tblProject Project);
        void DeleteProject(long id);
    }
}
