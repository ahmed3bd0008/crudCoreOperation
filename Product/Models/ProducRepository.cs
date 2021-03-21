using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{
    public class ProducRepository : IProducRepository
    {
        private readonly AppDbContext _context;

        public ProducRepository(AppDbContext context)
        {
            _context = context;
        }
        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int ProductId)
        {
            var product = _context.Products.Find(ProductId);
            if (product!=null)
            {
                _context.Products.Remove(product);
            }
            _context.SaveChanges();
            return product;
        }

        public Product Edit(Product product)
        {
            var changeProduct = _context.Products.Attach(product);
            changeProduct.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return product;
        }

        public Product GetPrdouct(int ProductId)
        {
            var product = _context.Products.Find(ProductId);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
