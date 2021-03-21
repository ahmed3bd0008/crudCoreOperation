using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{

    public class Product
    {

        public int Id  { get; set; }
        [Required]
        [Display(Name ="product name")]
        public String ProductName { get; set; }
        [Display(Name = "product datatime")]
        [Required]
        public DateTime ProductDataTime { get; set; }
        
        public string ? PhotoPath { get; set; }

    }
}
