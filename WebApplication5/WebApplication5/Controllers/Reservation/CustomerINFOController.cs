using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;

namespace WebApplication5.Controllers.Reservation
{
    public class CustomerINFOController : Controller
    {
        // GET: CustomerINFO
        public ActionResult Index()
        {
            CustomerClass custcls = new CustomerClass();
            List<Customer> cust = custcls.GetCustomers();
            return View(cust);
        }
    }
}