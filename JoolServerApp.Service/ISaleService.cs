using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoolServerApp.Service
{
    public interface ISaleService
    {
        IEnumerable<tblSale> GetAllSales();
        tblSale GetSale(long id);
        void insertSale(tblSale sale);
        void UpdateSale(tblSale sale);
        void DeleteSale(long id);

    }
}
