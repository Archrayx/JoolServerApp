using JoolServerApp.Data;
using JoolServerApp.Repo;
using System.Collections.Generic;



namespace JoolServerApp.Service
{
    public class StateService : IStateService
    {
        private IRepository<tblState> stateRepository;
        public StateService(IRepository<tblState> stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        public void DeleteState(long id)
        {
            tblState state = stateRepository.Get(id);
            stateRepository.Remove(state);
            stateRepository.SaveChanges();
        }

        public IEnumerable<tblState> GetAllStates()
        {
            return stateRepository.GetAll();
        }

        public tblState GetState(long id)
        {
            return stateRepository.Get(id);
        }

        public void insertState(tblState state)
        {
            stateRepository.Insert(state);
            stateRepository.SaveChanges();

        }

        public void UpdateState(tblState state)
        {
            stateRepository.Update(state);
            stateRepository.SaveChanges();

        }
    }
}