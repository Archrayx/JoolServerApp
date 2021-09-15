using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Data;

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
