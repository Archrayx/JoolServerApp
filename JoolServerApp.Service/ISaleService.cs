using JoolServerApp.Data;
using System.Collections.Generic;

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
