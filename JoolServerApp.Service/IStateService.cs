using JoolServerApp.Data;
using System.Collections.Generic;

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
