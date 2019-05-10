using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        /// <summary>
        /// 1.SingleOrDefault()
        /// reference: https://stackoverflow.com/questions/23842998/the-model-item-passed-into-the-dictionary-is-of-type-system-linq-enumerable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            // 1.SingleOrDefault()
            // Without getting the first element of the list you are actually 
            // passing an enumerable list instead of a single item.
            var query = GetCustomers().SingleOrDefault(c => c.Id == id);

            //if (query == null)
            //{
            //    return HttpNotFound();
            //}
            
            return View(query);
        }

        private IEnumerable<Customer> GetCustomers()
        { 
            return new List<Customer>() 
            {
               new Customer { Id = 1, Name = "John Smith" },
               new Customer { Id = 2, Name = "Mary Jane" },
            };
        }
    }
}