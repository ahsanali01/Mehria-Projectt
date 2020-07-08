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
    public class BookingNewRecordController : Controller
    {
        // GET: Test
        public ActionResult CustomerInfoGet()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CustomerInfoPost(AddCustomerClass customer)
        {
            try
            {
                MehriamarqueeEntities2 mqe = new MehriamarqueeEntities2();
                Customer cust = new Customer();

                cust.CnicNo = customer.CnicNo;
                cust.customerName = customer.customerName;
                cust.mobileNo = customer.mobileNo;
                cust.address = customer.address;
                cust.remarks = customer.remarks;
                mqe.Customers.Add(cust);
                mqe.SaveChanges();
                TempData["message"] = "Record Added Successfully";

            }
            catch (Exception) { }
            return RedirectToAction("CustomerInfoGet");
        }



        public ActionResult MehndiFunctionGet()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult MyValues(AddNewFunction function)
        {
            try
            {
                MehriamarqueeEntities2 mqe = new MehriamarqueeEntities2();
                Bookingdata bookdata = new Bookingdata();

                Customer cust = new Customer();
                string latestCustomerID = cust.CnicNo;

                bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                bookdata.stagesCharges = function.stagesCharges;
                bookdata.basics_others = function.basics_others;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = 4;
                bookdata.ProgramId = 1;
                bookdata.TotalCharges = function.TotalCharges;





                mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                TempData["message"] = "Record Added Successfully";
            }
            catch (Exception) { }
         
            return RedirectToAction("CustomerInfoGet");

        }

        public ActionResult BaratFunctionGet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult BaratFunctionPost(AddNewFunction function)
        {
            try
            {
                MehriamarqueeEntities2 mqe = new MehriamarqueeEntities2();
                Bookingdata bookdata = new Bookingdata();

                Customer cust = new Customer();
                string latestCustomerID = cust.CnicNo;

                bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                bookdata.stagesCharges = function.stagesCharges;
                bookdata.basics_others = function.basics_others;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = 4;
                bookdata.ProgramId = 3;
                bookdata.TotalCharges = function.TotalCharges;





                mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                TempData["message"] = "Record Added Successfully";
            }
            catch (Exception) { }

            return RedirectToAction("CustomerInfoGet");

        }

        public ActionResult WalimaFunctionGet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult WalimaFunctionPost(AddNewFunction function)
        {
            try
            {
                MehriamarqueeEntities2 mqe = new MehriamarqueeEntities2();
                Bookingdata bookdata = new Bookingdata();

                Customer cust = new Customer();
                string latestCustomerID = cust.CnicNo;

                bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                bookdata.stagesCharges = function.stagesCharges;
                bookdata.basics_others = function.basics_others;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = 4;
                bookdata.ProgramId = 5;
                bookdata.TotalCharges = function.TotalCharges;





                mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                TempData["message"] = "Record Added Successfully";
            }
            catch (Exception) { }

            return RedirectToAction("CustomerInfoGet");

        }


        public ActionResult PartyFunctionGet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PartyFunctionPost(AddNewFunction function)
        {
            try
            {
                MehriamarqueeEntities2 mqe = new MehriamarqueeEntities2();
                Bookingdata bookdata = new Bookingdata();

                Customer cust = new Customer();
                string latestCustomerID = cust.CnicNo;

                bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                bookdata.stagesCharges = function.stagesCharges;
                bookdata.basics_others = function.basics_others;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = 4;
                bookdata.ProgramId = 7;
                bookdata.TotalCharges = function.TotalCharges;





                mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                TempData["message"] = "Record Added Successfully";
            }
            catch (Exception) { }

            return RedirectToAction("CustomerInfoGet");

        }
    }
}