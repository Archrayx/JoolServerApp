using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public interface IStateService
    {
        IEnumerable<tblState> GetAllStates();
        tblState GetState(long id);
        void insertState(tblState state);
        void UpdateState(tblState state);
        void DeleteState(long id);
    }
}
