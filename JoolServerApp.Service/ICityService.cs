using JoolServerApp.Data;
using System.Collections.Generic;
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
