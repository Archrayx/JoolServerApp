using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface IManufacturerService
    {
        IEnumerable<tblManufacturer> GetAllManufacturers();
        tblManufacturer GetManufacturer(long id);
        void insertManufacturer(tblManufacturer manufacturer);
        void UpdateManufacturer(tblManufacturer manufacturer);
        void DeleteManufacturer(long id);
    }
}
