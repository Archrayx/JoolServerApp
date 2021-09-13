using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Repo;

namespace JoolServerApp.Service
{
    public class SaleService : ISaleService
    {
        private IRepository<tblSale> saleRepository;
        public SaleService(IRepository<tblSale> saleRepository)
        {
            this.saleRepository = saleRepository;
        }
        public void DeleteSale(long id)
        {
            tblSale sale=saleRepository.Get(id);
            saleRepository.Remove(sale);
            saleRepository.SaveChanges();
        }

        public IEnumerable<tblSale> GetAllSales()
        {
            return saleRepository.GetAll();
        }

        public tblSale GetSale(long id)
        {
            return saleRepository.Get(id);
        }

        public void insertSale(tblSale sale)
        {
            saleRepository.Insert(sale);
            saleRepository.SaveChanges();

        }

        public void UpdateSale(tblSale sale)
        {
            saleRepository.Update(sale);
            saleRepository.SaveChanges();

        }
    }
}