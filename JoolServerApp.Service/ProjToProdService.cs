using JoolServerApp.Data;
using JoolServerApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoolServerApp.Service
{
    public class ProjToProdService : IProjToProdService
    {
        private IRepository<tblProjToProd> projToProdRepository;
        public ProjToProdService(IRepository<tblProjToProd> projToProdRepository)
        {
            this.projToProdRepository = projToProdRepository;
        }

        public void DeleteProjectToProd(long id)
        {
            List<tblProjToProd> projToProd = (from projtoprod in projToProdRepository.GetAll()
                                              where projtoprod.Project_ID == id
                                              select projtoprod).ToList();
            for(int i = 0; i < projToProd.Count(); i++)
            {
                projToProdRepository.Remove(projToProd[i]);
                projToProdRepository.SaveChanges();
            }
        }

        public void DeleteProjToProd(long id,long id2)
        {
           tblProjToProd projToProd = GetProjToProd(id, id2);
            projToProdRepository.Remove(projToProd);
            projToProdRepository.SaveChanges();
        }

        public void DeleteProjToProduct(long id)
        {
            List<tblProjToProd> projToProd = (from projtoprod in projToProdRepository.GetAll()
                                              where projtoprod.Product_ID == id
                                              select projtoprod).ToList();
            for (int i = 0; i < projToProd.Count(); i++)
            {
                projToProdRepository.Remove(projToProd[i]);
                projToProdRepository.SaveChanges();
            }
            throw new NotImplementedException();
        }

        public tblProjToProd GetProjToProd(long id,long id2)
        {
          List<tblProjToProd> projToProd = (from projtoprod in projToProdRepository.GetAll()
                                      where projtoprod.Product_ID == id && projtoprod.Project_ID == id2
                                            select projtoprod).ToList();
            return projToProd[0];

        }

        public IEnumerable<tblProjToProd> GetProjToProds()
        {
            return projToProdRepository.GetAll();
        }

        public void insertProjToProd(tblProjToProd projToProd)
        {
            projToProdRepository.Insert(projToProd);
            projToProdRepository.SaveChanges();
        }

        public void UpdateProjToProd(tblProjToProd projToProd)
        {
            projToProdRepository.Update(projToProd);
            projToProdRepository.SaveChanges();
        }
    }
}