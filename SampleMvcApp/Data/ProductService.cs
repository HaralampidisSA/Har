using Har.Domain.Repositories;
using System.Collections.Generic;

namespace SampleMvcApp.Data
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repo;

        public ProductService(IRepository<Product> repository)
        {
            _repo = repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetAll();
        }
    }
}
