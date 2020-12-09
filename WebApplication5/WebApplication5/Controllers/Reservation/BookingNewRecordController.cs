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
    public class BookingNewRecordController : Controller
    {
        int functionId;
        // GET: Test
        public ActionResult CustomerInfoGet()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            ViewData["CustomerInfo"] = meh.Customers.ToList();
          
            return View();
        }
        [HttpPost]
        public ActionResult CustomerInfoPost(AddCustomerClass customer)
        {
            
                MehriamarqueeEntities mqe = new MehriamarqueeEntities();
                Customer cust = new Customer();

            Customer getcust = new Customer();
            getcust = mqe.Customers.Where(X => X.CnicNo == customer.CnicNo).FirstOrDefault();
                if (getcust == null)
                {
                    cust.CnicNo = customer.CnicNo;
                    cust.customerName = customer.customerName;
                    cust.mobileNo = customer.mobileNo;
                    cust.address = customer.address;
                    cust.remarks = customer.remarks;
                    mqe.Customers.Add(cust);
                    mqe.SaveChanges();
                    TempData["message"] = "Record Added Successfully";
                    return RedirectToAction("CustomerInfoGet");
                }
                else
                {
                   ModelState.AddModelError("", "User already Exisit with this CNIC NO");
                   
                }
           
            return View("CustomerInfoGet");
        }



        public ActionResult MehndiFunctionGet()
        {
          
           

            return View();
        }
        [HttpPost]
        public ActionResult MyValues(AddNewFunction function,string BasicStage,string Dj,string Electricity,string AcHeating,string FullHall)
        {
            
            try
            {
                if (function.bookingDate > DateTime.Today && function.functionDate > function.bookingDate)
                {
                    MehriamarqueeEntities mqe = new MehriamarqueeEntities();
                    Bookingdata bookdata = new Bookingdata();
                    List<Bookingdata> checkdate = new List<Bookingdata>();
                    checkdate= mqe.Bookingdatas.Where(X => X.functionDate==function.functionDate).ToList();
                    foreach (var item in checkdate)
                    {
                        if (item.functionDate == function.functionDate) {
                            TempData["message"] = " Function Date Already Exisit";
                            goto ended;
                        }
                    }
                    
                        Customer cust = new Customer();
                    cust = mqe.Customers.Where(X => X.CnicNo == function.CnicNo).FirstOrDefault();

                    bookdata.bookingDate = function.bookingDate;

                        bookdata.functionDate = function.functionDate;
                        bookdata.noofGuest = function.noofGuest;
                        bookdata.rateperGuest = function.rateperGuest;
                    var totalrate = function.noofGuest * function.rateperGuest;
                    bookdata.AdvancePayment= function.AdvancePayment;
                        bookdata.RemainingPayment = function.RemainingPayment;
                        bookdata.Extras = function.Extras;
                        bookdata.CnicNo = function.CnicNo;
                        bookdata.timeShift = function.timeShift;
                        bookdata.MenuId = function.MenuId;
                        bookdata.customerID = cust.customerID;
                        bookdata.ProgramId = 1;
                    bookdata.RequestStatus = "false";
                    Nullable<int> additionalTotal = 0;
                    if(function.stagePrice!= null)
                    {
                        additionalTotal = additionalTotal + function.stagePrice;
                    }
                    if (function.DjPrice != null)
                    {
                        additionalTotal = additionalTotal + function.DjPrice;
                    }
                    if (function.electriccityPrice != null)
                    {
                        additionalTotal = additionalTotal + function.electriccityPrice;
                    }
                    if (function.FullHallPrice != null)
                    {
                        additionalTotal = additionalTotal + function.FullHallPrice;
                    }
                    if (function.AcHeatingPrice != null)
                    {
                        additionalTotal = additionalTotal + function.AcHeatingPrice;
                    }

                    var fullTotal = totalrate + function.AdvancePayment + function.RemainingPayment + function.Extras +additionalTotal;
                     
                    bookdata.TotalCharges = fullTotal ?? default(int);
                    ViewBag.fullTotal = fullTotal;


                    mqe.Bookingdatas.Add(bookdata);
                        mqe.SaveChanges();
                        functionId = bookdata.functionID;
                        AdditionalFacilitiesandFunction facility = new AdditionalFacilitiesandFunction();
                        if (BasicStage == "true")
                        {
                            facility.functionID = functionId;
                            facility.additionalID = 1;
                            facility.additionalFacilityPrice = function.stagePrice;
                            mqe.AdditionalFacilitiesandFunctions.Add(facility);
                            mqe.SaveChanges();
                        }
                        if (Dj == "true")
                        {
                            facility.functionID = functionId;
                            facility.additionalID = 2;
                            facility.additionalFacilityPrice = function.DjPrice;
                            mqe.AdditionalFacilitiesandFunctions.Add(facility);
                            mqe.SaveChanges();
                        }
                        if (Electricity == "true")
                        {
                            facility.functionID = functionId;
                            facility.additionalID = 3;
                            facility.additionalFacilityPrice = function.electriccityPrice;
                            mqe.AdditionalFacilitiesandFunctions.Add(facility);
                            mqe.SaveChanges();
                        }
                        if (AcHeating == "true")
                        {
                            facility.functionID = functionId;
                            facility.additionalID = 4;
                            facility.additionalFacilityPrice = function.AcHeatingPrice;
                            mqe.AdditionalFacilitiesandFunctions.Add(facility);
                            mqe.SaveChanges();
                        }
                        if (FullHall == "true")
                        {
                            facility.functionID = functionId;
                            facility.additionalID = 5;
                            facility.additionalFacilityPrice = function.FullHallPrice;
                            mqe.AdditionalFacilitiesandFunctions.Add(facility);
                            mqe.SaveChanges();
                        }
                        TempData["message"] = "Record Added Successfully";
                    }
                

                else
                {
                   
                    TempData["message"] = "Booking Date Must be greater than today Date and Function Date must be Greater than Booking Date";
                }
               
            }
            catch (Exception) { }
            ended:
            ;
            return RedirectToAction("CustomerInfoGet");
       
           

        }
    

        public ActionResult BaratFunctionGet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult BaratFunctionPost(AddNewFunction function, string BasicStage, string Dj, string Electricity, string AcHeating, string FullHall)
        {
            try
            {
                if (function.bookingDate > DateTime.Today && function.functionDate > function.bookingDate)
                {
                    MehriamarqueeEntities mqe = new MehriamarqueeEntities();
                Bookingdata bookdata = new Bookingdata();
                    List<Bookingdata> checkdate = new List<Bookingdata>();
                    checkdate = mqe.Bookingdatas.Where(X => X.functionDate == function.functionDate).ToList();
                    foreach (var item in checkdate)
                    {
                        if (item.functionDate == function.functionDate)
                        {
                            TempData["message"] = " Function Date Already Exisit";
                            goto ended;
                        }
                    }
                    Customer cust = new Customer();
                    cust = mqe.Customers.Where(X => X.CnicNo == function.CnicNo).FirstOrDefault();

                    bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                    var totalrate = function.noofGuest * function.rateperGuest;
                bookdata.AdvancePayment = function.AdvancePayment;
                bookdata.RemainingPayment = function.RemainingPayment;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = function.MenuId;
                    bookdata.customerID = cust.customerID;
                    bookdata.ProgramId = 3;
                    bookdata.RequestStatus = "false";
                    Nullable<int> additionalTotal = 0;
                    if (function.stagePrice != null)
                    {
                        additionalTotal = additionalTotal + function.stagePrice;
                    }
                    if (function.DjPrice != null)
                    {
                        additionalTotal = additionalTotal + function.DjPrice;
                    }
                    if (function.electriccityPrice != null)
                    {
                        additionalTotal = additionalTotal + function.electriccityPrice;
                    }
                    if (function.FullHallPrice != null)
                    {
                        additionalTotal = additionalTotal + function.FullHallPrice;
                    }
                    if (function.AcHeatingPrice != null)
                    {
                        additionalTotal = additionalTotal + function.AcHeatingPrice;
                    }

                    var fullTotal = totalrate + function.AdvancePayment + function.RemainingPayment + function.Extras + additionalTotal;

                    bookdata.TotalCharges = fullTotal ?? default(int);
                    ViewBag.fullTotal = fullTotal;



                   

                    TempData["fullTotal"] = fullTotal;



                mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                    functionId = bookdata.functionID;
                    AdditionalFacilitiesandFunction facility = new AdditionalFacilitiesandFunction();
                    if (BasicStage == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 1;
                        facility.additionalFacilityPrice = function.stagePrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (Dj == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 2;
                        facility.additionalFacilityPrice = function.DjPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (Electricity == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 3;
                        facility.additionalFacilityPrice = function.electriccityPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (AcHeating == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 4;
                        facility.additionalFacilityPrice = function.AcHeatingPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (FullHall == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 5;
                        facility.additionalFacilityPrice = function.FullHallPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    TempData["message"] = "Record Added Successfully";
                }

                else
                {
                    TempData["message"] = "Booking Date Must be greater than today Date and Function Date must be Greater than Booking Date";
                }
               
            }
            catch (Exception) { }
            ended:
            ;
            return RedirectToAction("CustomerInfoGet");

        }

        public ActionResult WalimaFunctionGet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult WalimaFunctionPost(AddNewFunction function, string BasicStage, string Dj, string Electricity, string AcHeating, string FullHall)
        {
            try
            {
                if (function.bookingDate > DateTime.Today && function.functionDate > function.bookingDate)
                {
                    MehriamarqueeEntities mqe = new MehriamarqueeEntities();
                Bookingdata bookdata = new Bookingdata();
                    List<Bookingdata> checkdate = new List<Bookingdata>();
                    checkdate = mqe.Bookingdatas.Where(X => X.functionDate == function.functionDate).ToList();
                    foreach (var item in checkdate)
                    {
                        if (item.functionDate == function.functionDate)
                        {
                            TempData["message"] = " Function Date Already Exisit";
                            goto ended;
                        }
                    }
                    Customer cust = new Customer();
                    cust = mqe.Customers.Where(X => X.CnicNo == function.CnicNo).FirstOrDefault();

                    bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                    var totalrate = function.noofGuest * function.rateperGuest;
                    bookdata.AdvancePayment = function.AdvancePayment;
                bookdata.RemainingPayment= function.RemainingPayment;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = function.MenuId;
                    bookdata.customerID = cust.customerID;
                    bookdata.ProgramId = 5;

                    bookdata.RequestStatus = "false";

                    Nullable<int> additionalTotal = 0;
                    if (function.stagePrice != null)
                    {
                        additionalTotal = additionalTotal + function.stagePrice;
                    }
                    if (function.DjPrice != null)
                    {
                        additionalTotal = additionalTotal + function.DjPrice;
                    }
                    if (function.electriccityPrice != null)
                    {
                        additionalTotal = additionalTotal + function.electriccityPrice;
                    }
                    if (function.FullHallPrice != null)
                    {
                        additionalTotal = additionalTotal + function.FullHallPrice;
                    }
                    if (function.AcHeatingPrice != null)
                    {
                        additionalTotal = additionalTotal + function.AcHeatingPrice;
                    }

                    var fullTotal = totalrate + function.AdvancePayment + function.RemainingPayment + function.Extras + additionalTotal;

                    bookdata.TotalCharges = fullTotal ?? default(int);
                    ViewBag.fullTotal = fullTotal;





                    TempData["fullTotal"] = fullTotal;


                    mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                    functionId = bookdata.functionID;
                    AdditionalFacilitiesandFunction facility = new AdditionalFacilitiesandFunction();
                    if (BasicStage == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 1;
                        facility.additionalFacilityPrice = function.stagePrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (Dj == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 2;
                        facility.additionalFacilityPrice = function.DjPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (Electricity == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 3;
                        facility.additionalFacilityPrice = function.electriccityPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (AcHeating == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 4;
                        facility.additionalFacilityPrice = function.AcHeatingPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (FullHall == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 5;
                        facility.additionalFacilityPrice = function.FullHallPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    TempData["message"] = "Record Added Successfully";
            }

                else
                {
                TempData["message"] = "Booking Date Must be greater than today Date and Function Date must be Greater than Booking Date";
            }
            
            }
            catch (Exception) { }
            ended:
            ;
            return RedirectToAction("CustomerInfoGet");

        }


        public ActionResult PartyFunctionGet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PartyFunctionPost(AddNewFunction function, string BasicStage, string Dj, string Electricity, string AcHeating, string FullHall)
        {
            try
            {
                if (function.bookingDate > DateTime.Today && function.functionDate > function.bookingDate)
                {
                    MehriamarqueeEntities mqe = new MehriamarqueeEntities();
                Bookingdata bookdata = new Bookingdata();
                    List<Bookingdata> checkdate = new List<Bookingdata>();
                    checkdate = mqe.Bookingdatas.Where(X => X.functionDate == function.functionDate).ToList();
                    foreach (var item in checkdate)
                    {
                        if (item.functionDate == function.functionDate)
                        {
                            TempData["message"] = " Function Date Already Exisit";
                            goto ended;
                        }
                    }
                    Customer cust = new Customer();
                    cust = mqe.Customers.Where(X => X.CnicNo == function.CnicNo).FirstOrDefault();

                    bookdata.bookingDate = function.bookingDate;
                bookdata.functionDate = function.functionDate;
                bookdata.noofGuest = function.noofGuest;
                bookdata.rateperGuest = function.rateperGuest;
                    var totalrate = function.noofGuest * function.rateperGuest;
                    bookdata.AdvancePayment = function.AdvancePayment;
                bookdata.RemainingPayment = function.RemainingPayment;
                bookdata.Extras = function.Extras;
                bookdata.CnicNo = function.CnicNo;
                bookdata.timeShift = function.timeShift;
                bookdata.MenuId = function.MenuId;
                    bookdata.customerID = cust.customerID;
                    bookdata.ProgramId = 7;
                    bookdata.RequestStatus = "false";
                    Nullable<int> additionalTotal = 0;
                    if (function.stagePrice != null)
                    {
                        additionalTotal = additionalTotal + function.stagePrice;
                    }
                    if (function.DjPrice != null)
                    {
                        additionalTotal = additionalTotal + function.DjPrice;
                    }
                    if (function.electriccityPrice != null)
                    {
                        additionalTotal = additionalTotal + function.electriccityPrice;
                    }
                    if (function.FullHallPrice != null)
                    {
                        additionalTotal = additionalTotal + function.FullHallPrice;
                    }
                    if (function.AcHeatingPrice != null)
                    {
                        additionalTotal = additionalTotal + function.AcHeatingPrice;
                    }

                    var fullTotal = totalrate + function.AdvancePayment + function.RemainingPayment + function.Extras + additionalTotal;

                    bookdata.TotalCharges = fullTotal ?? default(int);
                    ViewBag.fullTotal = fullTotal;





                    mqe.Bookingdatas.Add(bookdata);
                mqe.SaveChanges();
                    functionId = bookdata.functionID;
                    AdditionalFacilitiesandFunction facility = new AdditionalFacilitiesandFunction();
                    if (BasicStage == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 1;
                        facility.additionalFacilityPrice = function.stagePrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (Dj == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 2;
                        facility.additionalFacilityPrice = function.DjPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (Electricity == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 3;
                        facility.additionalFacilityPrice = function.electriccityPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (AcHeating == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 4;
                        facility.additionalFacilityPrice = function.AcHeatingPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    if (FullHall == "true")
                    {
                        facility.functionID = functionId;
                        facility.additionalID = 5;
                        facility.additionalFacilityPrice = function.FullHallPrice;
                        mqe.AdditionalFacilitiesandFunctions.Add(facility);
                        mqe.SaveChanges();
                    }
                    TempData["message"] = "Record Added Successfully";
                }

                else
                {
                    TempData["message"] = "Booking Date Must be greater than today Date and Function Date must be Greater than Booking Date";
                }
              
            }

            catch (Exception) { }
            ended:
            ;
            return RedirectToAction("CustomerInfoGet");

        }

   


    }
}