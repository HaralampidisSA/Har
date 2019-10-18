using System.Collections.Generic;

namespace SampleMvcApp.Data
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
