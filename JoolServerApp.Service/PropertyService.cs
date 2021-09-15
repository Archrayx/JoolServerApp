using System.Collections.Generic;
using JoolServerApp.Repo;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public class PropertyService : IPropertyService
    {
        private IRepository<tblProperty> propertyRepository;

        public PropertyService(IRepository<tblProperty> propertyRepository)
        {
            this.propertyRepository = propertyRepository;
        }

        public IEnumerable<tblProperty> GetAllProperties()
        {
            return propertyRepository.GetAll();
        }
        public tblProperty GetProperty(long id)
        {
            return propertyRepository.Get(id);
        }
        public void insertProperty(tblProperty property)
        {
            propertyRepository.Insert(property);
            propertyRepository.SaveChanges();

        }
        public void UpdateProperty(tblProperty property)
        {
            propertyRepository.Update(property);
            propertyRepository.SaveChanges();

        }

        public void DeleteProperty(long id)
        {
            tblProperty property = GetProperty(id);
            propertyRepository.Remove(property);
            propertyRepository.SaveChanges();
        }
    }
}
