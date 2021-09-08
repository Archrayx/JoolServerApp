using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoolServerApp.Repo.Interfaces
{
    interface ILogin
    {
        public string UserID { get; set; }
        public string Password { get; set; }

        public bool CheckLogin { get; set; };
        public void Authenticate(dbContext);
    }
}
