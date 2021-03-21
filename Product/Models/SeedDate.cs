using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{
    public static class  SeedDate
    {
        public static void  intializedata(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product() { ProductName = "product1", ProductDataTime = DateTime.Now,
                        PhotoPath = "1" ,Id=1});
        }
    }
}
