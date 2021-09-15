using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
