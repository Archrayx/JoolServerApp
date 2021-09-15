using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
