using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoolServerApp.Data;
namespace JoolServerApp.Service
{
    public interface ICityService
    {
        IEnumerable<tblCity> GetAllCities();
        tblCity GetCity(long id);
        void insertCity(tblCity city);
        void UpdateCity(tblCity city);
        void DeleteCity(long id);
    }
}
