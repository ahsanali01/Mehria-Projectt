using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;

namespace WebApplication5.Controllers.Reservation
{
    [Authorize(Roles = "Reservator")]
    public class CustomerINFOController : Controller
    {
        // GET: CustomerINFO
        public ActionResult Index()
        {
            CustomerClass custcls = new CustomerClass();
            List<Customer> cust = custcls.GetCustomers();
            return View(cust);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index(long SearchtermCnic=0,long SearchtermMobile=0)
        {
            if (SearchtermCnic == 0 && SearchtermMobile==0) { RedirectToAction("Index"); }
            if (SearchtermMobile == 0)
            {
                CustomerClass custcls = new CustomerClass();
                List<Customer> cust = custcls.FindCustomer(SearchtermCnic);
                return View(cust);
            }
            else
            {
                MehriamarqueeEntities meh = new MehriamarqueeEntities();
                List<Customer> cust = meh.Customers.Where(X=>X.mobileNo== SearchtermMobile).ToList();
                return View(cust);
            }
        }

        public ActionResult EditCustomer(long id)
        {   
            CustomerClass custcls = new CustomerClass();
            Customer cust = custcls.UpdateCustomer(id);
            return View(cust);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer cus)
        {
            if (ModelState.IsValid) { 
            CustomerClass custcls = new CustomerClass();
           custcls.UpdateCustomerSave(cus);
                return RedirectToAction("Index", "CustomerINFO");
                }
            return View(cus);
        }

        public ActionResult DeleteCustomer(long id)
        {
            try
            {
                if (id != 0)
                {
                    CustomerClass custcls = new CustomerClass();
                    custcls.DeleteCustomerbyID(id);
                }
                
            }
            catch (Exception)
            {
                TempData["message"] = "Cannot Remove!Record can be Altered only";
            }
            return RedirectToAction("Index", "CustomerINFO");


        }
    }
}