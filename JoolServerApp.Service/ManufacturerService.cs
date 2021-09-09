using System.Collections.Generic;
using JoolServerApp.Repo;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public class ManufacturerService : IManufacturerService
    {
        private IRepository<tblManufacturer> manufacturerRepository;

        public ManufacturerService(IRepository<tblManufacturer> manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }
        public void DeleteManufacturer(long id)
        {

            tblManufacturer manufacturer = manufacturerRepository.Get(id);
            manufacturerRepository.Remove(manufacturer);
            manufacturerRepository.SaveChanges();

        }

        public IEnumerable<tblManufacturer> GetAllManufacturers()
        {
            return manufacturerRepository.GetAll();
        }

        public tblManufacturer GetManufacturer(long id)
        {
            return manufacturerRepository.Get(id);
        }

        public void insertManufacturer(tblManufacturer manufacturer)
        {
            manufacturerRepository.Insert(manufacturer);
        }

        public void UpdateManufacturer(tblManufacturer manufacturer)
        {
            manufacturerRepository.Update(manufacturer);
        }
    }
}