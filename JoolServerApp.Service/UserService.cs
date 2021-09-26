using JoolServerApp.Data;
using JoolServerApp.Repo;
using System.Collections.Generic;
using System.Diagnostics;

namespace JoolServerApp.Service
{
    public class UserService : IUserService
    {
        private IRepository<tblUser> userRepository;

        public UserService(IRepository<tblUser> userRepository)
        {
            this.userRepository = userRepository;
            Debug.WriteLine(this.userRepository);
        }

        public IEnumerable<tblUser> GetAllUsers()
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
            userRepository.SaveChanges();
        }
        public void UpdateUser(tblUser user)
        {
            userRepository.Update(user);
            userRepository.SaveChanges();
        }

        public void DeleteUser(long id)
        {
            tblUser user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

    }
}
