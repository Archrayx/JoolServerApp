using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface IUserService
    {
        IEnumerable<tblUser> GetAllUsers();
        tblUser GetUser(long id);
        void insertUser(tblUser user);
        void UpdateUser(tblUser user);
        void DeleteUser(long id);

    }
}