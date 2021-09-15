using JoolServerApp.Data;
using JoolServerApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoolServerApp.Service
{
    public class CityService:ICityService
    {
        private IRepository<tblCity> cityRepository;

        public CityService(IRepository<tblCity> cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public void DeleteCity(long id)
        {
            tblCity city=cityRepository.Get(id);
            cityRepository.Remove(city);
            cityRepository.SaveChanges();
        }

        public IEnumerable<tblCity> GetAllCities()
        {
           return cityRepository.GetAll();
        }

        public tblCity GetCity(long id)
        {
            return cityRepository.Get(id);
        }

        public void insertCity(tblCity city)
        {
            cityRepository.Insert(city);
            cityRepository.SaveChanges();
        }

        public void UpdateCity(tblCity city)
        {
            cityRepository.Update(city);
            cityRepository.SaveChanges();
        }
    }
}