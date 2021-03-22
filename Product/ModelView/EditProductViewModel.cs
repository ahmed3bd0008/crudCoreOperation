using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.ModelView
{
    public class EditProductViewModel:CreateProduct
    {
       public string existingImage { set; get; }
    }
}
