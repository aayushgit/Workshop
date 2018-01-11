using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkshopManager.Models;
using WorkshopManager.Models.ViewModels;


namespace WorkshopManager.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Products
        public ActionResult All()
        {
            var products = _context.Products.ToList();
         

            var viewModel = new AllProductsViewModel
            {
                Product = products
                
                
            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.ProductTypeId).SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();

            var viewModel = new AllProductsViewModel()
            {
                Product = new List<Product> { product }

            };
            return View(viewModel);
        }
        public ActionResult New()
        {
            var productTypes = _context.ProductTypes.ToList();
            var viewModel = new ProductFormViewModel()
            {
                Product = new Product(),
               ProductTypes = productTypes
            };
            return View("ProductForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)  //model binding
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel()
                {
                    Product = product
                };
                return View("ProductForm", viewModel);
            }
            if (product.Id == 0)
            {
                _context.Products.Add(product);
                 
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Price = product.Price;
                productInDb.Stock = product.Stock;
                productInDb.ProductTypeId.Name = product.ProductTypeId.Name;
                productInDb.ModelNo = product.ModelNo;


            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
            return RedirectToAction("All","Products");
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product==null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductFormViewModel()
            {
                Product = product,
                ProductTypes = _context.ProductTypes.ToList()
            };

            return View("ProductForm",viewModel);
        }
    }
}