using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Models;
using Product.ModelView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProducRepository _repository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IProducRepository repository, IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_repository.GetProducts().ToList());
        }
        public IActionResult Create(CreateProduct model)
        {
            string uniquename = this.uploadFile(model);
            Product.Models.Product product = new Models.Product()
            {
                ProductName = model.ProductName,
                ProductDataTime = model.ProductDataTime,
                PhotoPath = uniquename
            };
            _repository.Add(product);
            return RedirectToAction("Index");
        }
       
            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
       
        public IActionResult Delete(int ProductId)
        {
            _repository.Delete(ProductId);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {

            var product = _repository.GetPrdouct(id);
            EditProductViewModel model = new EditProductViewModel()
            {
                ProductName = product.ProductName,
                ProductDataTime = product.ProductDataTime,
                existingImage =product.PhotoPath
            };
            if (product!=null)
            {
                return View(model);
            }
            return View("Index",_repository.GetProducts().ToList());
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            var product = _repository.GetPrdouct(model.Id);
            string uniqueFile;
            if (product!=null)
            {
                product.ProductName = model.ProductName;
                product.ProductDataTime = model.ProductDataTime;
                uniqueFile = uploadFile(model);
                if (model.PhotoPath != null)
                {
                    product.PhotoPath = uniqueFile;
                }
            }
            if (model.existingImage != null)
            {
                //كده انا مسكت المسار بتاع الصوره
                string filename = Path.Combine(_hostEnvironment.WebRootPath, "Image", model.existingImage);
                System.IO.File.Delete(filename);
            }
            _repository.Edit(product);
            return  RedirectToAction("index");
        }
        public string uploadFile(CreateProduct product)
        {
            string Uniquename = null;
            if (product.PhotoPath != null && product.PhotoPath.Count > 0)
            {
                foreach (var item in product.PhotoPath)
                {
                    String UploadFolder = Path.Combine(_hostEnvironment .WebRootPath, "Image");
                    Uniquename = Guid.NewGuid().ToString() + "_" + item.FileName;
                    String filename = Path.Combine(UploadFolder, Uniquename);
                    //useing is used to when this blockexecuted immedaitly dispose
                    using (var filestream = new FileStream(filename, FileMode.Create))
                    {
                        item.CopyTo(filestream);
                    }
                }
            }
            return Uniquename;
        }
    }
}
