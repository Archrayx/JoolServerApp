using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Data;

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