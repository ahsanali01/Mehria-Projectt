using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers
{
    [Authorize]
    public class BookingFormController : Controller
    {
        // GET: BookingForm
        public ActionResult Index()

        {
            
            return View();

        }
        [HttpPost]
        public ActionResult AddCustomerRecord(personalclass persn,BookingDetail book)
        {
            MehriamarqueeEntities2 objforcontext = new MehriamarqueeEntities2();
            objforcontext.Customers.Add(new Customer() { CnicNo = persn.idNo.ToString(), customerName = persn.nameOfCustomer, mobileNo = persn.mobileNo.ToString(), address = persn.address, remarks = persn.remarks });
            objforcontext.SaveChanges();
            
           
            return View("personalclass", persn);
            
        }
        public ActionResult AddBookingRecord(personalclass persn, BookingDetail book)
        {
            MehriamarqueeEntities2 objforcontext = new MehriamarqueeEntities2();
            objforcontext.Customers.Add(new Customer() { CnicNo = persn.idNo.ToString(), customerName = persn.nameOfCustomer, mobileNo = persn.mobileNo.ToString(), address = persn.address, remarks = persn.remarks });
            objforcontext.SaveChanges();

            MehriamarqueeEntities4 objforBookContext = new MehriamarqueeEntities4();
            objforBookContext.Bookingdatas.Add(new Bookingdata() { bookingDate = persn.bookingDate, functionDate = book.FunctionOccuransDate, noofGuest = book.noOfGuest, rateperGuest = book.ratePerGuest, stagesCharges = book.stagescharges, basics_others = book.basicsOthers, Extras = book.Extras, TotalCharges = book.TotalCharges, timeShift = book.timeShift });
            return View("Booking", book);

        }


    }
}