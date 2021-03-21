using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.ModelView
{
    public class CreateProduct
    {


        public int Id { get; set; }
        [Required]
        [Display(Name = "product name")]
        public String ProductName { get; set; }
        [Display(Name = "product datatime")]
        [Required]
        public DateTime ProductDataTime { get; set; }

        public  List<IFormFile> ? PhotoPath { get; set; }

    }
}

