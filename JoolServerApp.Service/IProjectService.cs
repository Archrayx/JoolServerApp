using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
