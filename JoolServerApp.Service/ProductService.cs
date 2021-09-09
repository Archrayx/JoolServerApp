using System.Collections.Generic;
using JoolServerApp.Repo;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public class ProductService : IProductService
    {
        private IRepository<tblProduct> productRepository;

        public ProductService(IRepository<tblProduct> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<tblProduct> GetAllProducts()
        {
            return productRepository.GetAll();
        }
        public tblProduct GetProduct(long id)
        {
            return productRepository.Get(id);
        }
        public void insertProduct(tblProduct product)
        {
            productRepository.Insert(product);
        }
        public void UpdateProduct(tblProduct product)
        {
            productRepository.Update(product);
        }

        public void DeleteProduct(long id)
        {
            tblProduct product = GetProduct(id);
            productRepository.Remove(product);
            productRepository.SaveChanges();
        }

        
    }
}
