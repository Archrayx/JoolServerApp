using System.Collections.Generic;
using JoolServerApp.Repo;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public class UserService:IUserService
    {
        private IRepository<tblUser> userRepository;

        public UserService(IRepository<tblUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<tblUser> GetUsers()
        {
            return userRepository.GetAll();
        }
        public tblUser GetUser(long id)
        {
            return userRepository.Get(id);
        }
        public void insertUser(tblUser user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(tblUser user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            tblUser user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

    }
}
