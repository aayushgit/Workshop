using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkshopManager.Models;
using WorkshopManager.Models.ViewModels;

namespace WorkshopManager.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult All()
        {
            var customer = _context.Customers.ToList();
            
            var viewModel = new AllCustomersViewModel
            {
                Customer = customer

            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new AllCustomersViewModel
            {
                Customer =  new List<Customer> {customer}

            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer()
                
            };

            return View("CustomerForm");
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer ) //form data automatically binded
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.Single(p => p.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
                customerInDb.Contact = customer.Contact;
                //TryUpdateModel(customerInDb); --- Not good since it leaves security holes
            }
            _context.SaveChanges(); //save as SQL and Run
            return RedirectToAction("All", "Customer");

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer
            };
            return View("CustomerForm",viewModel);
        }
        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer() {Id = 1, Name = "James Franko", Contact = "9801123453"},
                new Customer() {Id = 2, Name = "Dave Franko", Contact = "9801123453"}

            };
        }*/


    }
    }
