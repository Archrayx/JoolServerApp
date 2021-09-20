using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public interface IProjToProdService
    {
        //left is project, right is product
        IEnumerable<tblProjToProd> GetProjToProds();

        tblProjToProd GetProjToProd(long id,long id2);

        void insertProjToProd(tblProjToProd projToProd);

        void UpdateProjToProd(tblProjToProd projToProd);
        void DeleteProjToProd(long id,long id2);
        void DeleteProjectToProd(long id);
        void DeleteProjToProduct(long id);


    }
}
