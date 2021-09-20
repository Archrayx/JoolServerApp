using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface IProductService
    {
        IEnumerable<tblProduct> GetAllProducts();
        tblProduct GetProduct(long id);
        void insertProduct(tblProduct product);
        void UpdateProduct(tblProduct product);
        void DeleteProduct(long id);
    }
}
