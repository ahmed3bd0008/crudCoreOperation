using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{
   public interface IProducRepository
    {
        Product Add(Product product);
        Product Delete(int ProductId);
        Product GetPrdouct(int ProductId);
        IEnumerable<Product> GetProducts();
        Product Edit(Product product);

    }
}
