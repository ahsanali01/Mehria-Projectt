using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;
namespace WebApplication5.Controllers
{
    public class SendRequestForStockController : Controller
    {
        [Authorize]
        // GET: SendRequestForStock
        public ActionResult Index()
        {
            Bookingclass bookcls = new Bookingclass();
            List<Bookingdata> bookdata = bookcls.GetBookingdetail();
            return View(bookdata);
           
        }
    }
}