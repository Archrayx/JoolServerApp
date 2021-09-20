using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface IPropertyService
    {
        IEnumerable<tblProperty> GetAllProperties();
        tblProperty GetProperty(long id);
        void insertProperty(tblProperty property);
        void UpdateProperty(tblProperty property);
        void DeleteProperty(long id);
    }
}
