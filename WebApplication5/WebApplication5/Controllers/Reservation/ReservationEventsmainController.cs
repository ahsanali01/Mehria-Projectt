using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;

namespace WebApplication5.Controllers
{
    [Authorize]
    public class ReservationEventsmainController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Bookingclass bookcls = new Bookingclass();
            List<Bookingdata> bookdata = bookcls.GetBookingdetail();
            return View(bookdata);
        }
    }
}