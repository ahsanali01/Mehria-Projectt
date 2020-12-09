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
    
    [Authorize(Roles = "Reservator")]
    public class ReservationEventsmainController : Controller
    {
        int value;
        // GET: Home
        public ActionResult Index()
        {
            
            Bookingclass bookcls = new Bookingclass();
            List<Bookingdata> bookdata = bookcls.GetBookingdetail();
            return View(bookdata);
        }
    [Authorize]
        public ActionResult Alldetailoffunction()

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            List<Bookingdata> booklist = objforcontext.Bookingdatas.ToList();
            //BookingViewModel bookmodel = new BookingViewModel();
            //List<BookingViewModel> bookmodellist = booklist.Select(x => new BookingViewModel
            //{
            //    functionId = x.functionID,
            //    bookingDate = x.bookingDate,
            //    functionDate = x.functionDate,
            //    noofGuest = x.noofGuest,
            //    rateperGuest = x.rateperGuest,
            //    stagesCharges = x.AdvancePayment,
            //    basics_others = x.RemainingPayment,
            //    Extras = x.Extras,
            //    TotalCharges = x.TotalCharges,
            //    timeShift = x.timeShift,
            //    Menuname = x.Menu.menuName,
            //    ProgramName = x.Program.programName,
               
            //    CnicNo = x.CnicNo,
            //    customerName = x.Customer.customerName,
            //    Address = x.Customer.address,
            //    mobileNo = x.Customer.mobileNo,
            //    remarks = x.Customer.remarks,

            //    }).ToList();
          
            return View(booklist);
        }
[HttpPost,ValidateAntiForgeryToken]
        public ActionResult Alldetailoffunction(DateTime? SearchtermDate=null,long SearchtermCnic=0)

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            
           
            if(SearchtermDate==null && SearchtermCnic == 0) {
                TempData["message"] = " Function Date and CNIC No can't be Empty";
                RedirectToAction("Alldetailoffunction"); }
            if (SearchtermDate == null)
            {

                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.Customer.CnicNo == SearchtermCnic).ToList();
                return View(booklist);
            }
         if(SearchtermCnic==0)
            {
                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.functionDate == SearchtermDate).ToList();
                return View(booklist);
            }
            else
            {
                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.functionDate == SearchtermDate &&  X.Customer.CnicNo == SearchtermCnic).ToList();
                return View(booklist);
            }
        }

        public ActionResult MehndiEvents()

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X=>X.Program.programName== "Mehndi").ToList();
            //BookingViewModel bookmodel = new BookingViewModel();
            //List<BookingViewModel> bookmodellist = booklist.Select(x => new BookingViewModel
            //{
            //    functionId = x.functionID,
            //    bookingDate = x.bookingDate,
            //    functionDate = x.functionDate,
            //    noofGuest = x.noofGuest,
            //    rateperGuest = x.rateperGuest,
            //    stagesCharges = x.AdvancePayment,
            //    basics_others = x.RemainingPayment,
            //    Extras = x.Extras,
            //    TotalCharges = x.TotalCharges,
            //    timeShift = x.timeShift,
            //    Menuname = x.Menu.menuName,
            //    ProgramName = x.Program.programName,

            //    CnicNo = x.CnicNo,
            //    customerName = x.Customer.customerName,
            //    Address = x.Customer.address,
            //    mobileNo = x.Customer.mobileNo,
            //    remarks = x.Customer.remarks,

            //}).ToList();

            return View(booklist);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult MehndiEvents(DateTime? SearchtermDate = null, long SearchtermCnic = 0)

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();


            if (SearchtermDate == null && SearchtermCnic == 0) { RedirectToAction("Alldetailoffunction"); }
            if (SearchtermDate == null)
            {

                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.Customer.CnicNo == SearchtermCnic && X.Program.programName == "Mehndi").ToList();
                return View(booklist);
            }
            else
            {
                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.functionDate == SearchtermDate && X.Program.programName == "Mehndi").ToList();
                return View(booklist);
            }
        }
        public ActionResult BaratEvents()

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X=>X.Program.programName== "Barat/Nikkah").ToList();
            //BookingViewModel bookmodel = new BookingViewModel();
            //List<BookingViewModel> bookmodellist = booklist.Select(x => new BookingViewModel
            //{
            //    functionId = x.functionID,
            //    bookingDate = x.bookingDate,
            //    functionDate = x.functionDate,
            //    noofGuest = x.noofGuest,
            //    rateperGuest = x.rateperGuest,
            //    stagesCharges = x.AdvancePayment,
            //    basics_others = x.RemainingPayment,
            //    Extras = x.Extras,
            //    TotalCharges = x.TotalCharges,
            //    timeShift = x.timeShift,
            //    Menuname = x.Menu.menuName,
            //    ProgramName = x.Program.programName,

            //    CnicNo = x.CnicNo,
            //    customerName = x.Customer.customerName,
            //    Address = x.Customer.address,
            //    mobileNo = x.Customer.mobileNo,
            //    remarks = x.Customer.remarks,

            //}).ToList();

            return View(booklist);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult BaratEvents(DateTime? SearchtermDate = null, long SearchtermCnic = 0)

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();


            if (SearchtermDate == null && SearchtermCnic == 0) { RedirectToAction("Alldetailoffunction"); }
            if (SearchtermDate == null)
            {

                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.Customer.CnicNo == SearchtermCnic && X.Program.programName == "Barat/Nikkah").ToList();
                return View(booklist);
            }
            else
            {
                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.functionDate == SearchtermDate && X.Program.programName == "Barat/Nikkah").ToList();
                return View(booklist);
            }
        }
        public ActionResult WalimaEvents()

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X=> X.Program.programName=="Walima").ToList();
            //BookingViewModel bookmodel = new BookingViewModel();
            //List<BookingViewModel> bookmodellist = booklist.Select(x => new BookingViewModel
            //{
            //    functionId = x.functionID,
            //    bookingDate = x.bookingDate,
            //    functionDate = x.functionDate,
            //    noofGuest = x.noofGuest,
            //    rateperGuest = x.rateperGuest,
            //    stagesCharges = x.AdvancePayment,
            //    basics_others = x.RemainingPayment,
            //    Extras = x.Extras,
            //    TotalCharges = x.TotalCharges,
            //    timeShift = x.timeShift,
            //    Menuname = x.Menu.menuName,
            //    ProgramName = x.Program.programName,

            //    CnicNo = x.CnicNo,
            //    customerName = x.Customer.customerName,
            //    Address = x.Customer.address,
            //    mobileNo = x.Customer.mobileNo,
            //    remarks = x.Customer.remarks,

            //}).ToList();

            return View(booklist);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult WalimaEvents(DateTime? SearchtermDate = null, long SearchtermCnic = 0)

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();


            if (SearchtermDate == null && SearchtermCnic == 0) { RedirectToAction("Alldetailoffunction"); }
            if (SearchtermDate == null)
            {

                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.Customer.CnicNo == SearchtermCnic).ToList();
                return View(booklist);
            }
            else
            {
                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.functionDate == SearchtermDate).ToList();
                return View(booklist);
            }
        }
        public ActionResult PartyEvents()

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.Program.programName == "Party").ToList();
            //BookingViewModel bookmodel = new BookingViewModel();
            //List<BookingViewModel> bookmodellist = booklist.Select(x => new BookingViewModel
            //{
            //    functionId = x.functionID,
            //    bookingDate = x.bookingDate,
            //    functionDate = x.functionDate,
            //    noofGuest = x.noofGuest,
            //    rateperGuest = x.rateperGuest,
            //    stagesCharges = x.AdvancePayment,
            //    basics_others = x.RemainingPayment,
            //    Extras = x.Extras,
            //    TotalCharges = x.TotalCharges,
            //    timeShift = x.timeShift,
            //    Menuname = x.Menu.menuName,
            //    ProgramName = x.Program.programName,

            //    CnicNo = x.CnicNo,
            //    customerName = x.Customer.customerName,
            //    Address = x.Customer.address,
            //    mobileNo = x.Customer.mobileNo,
            //    remarks = x.Customer.remarks,

            //}).ToList();

            return View(booklist);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PartyEvents(DateTime? SearchtermDate = null, long SearchtermCnic = 0)

        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();


            if (SearchtermDate == null && SearchtermCnic == 0) { RedirectToAction("Alldetailoffunction"); }
            if (SearchtermDate == null)
            {

                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.Customer.CnicNo == SearchtermCnic && X.Program.programName == "Party").ToList();
                return View(booklist);
            }
            else
            {
                List<Bookingdata> booklist = objforcontext.Bookingdatas.Where(X => X.functionDate == SearchtermDate && X.Program.programName == "Party").ToList();
                return View(booklist);
            }
        }
        public ActionResult ActiveEvents()
        {
            Bookingclass bookcls = new Bookingclass();
            List<Bookingdata> bookdata = bookcls.GetBookingdetail();
            return View(bookdata);
        }

        public ActionResult DeactiveEvents()
        {
            Bookingclass bookcls = new Bookingclass();
            List<Bookingdata> bookdata = bookcls.GetBookingdetail();
            return View(bookdata);
        }

      

             public ActionResult Reminder()
        {
            Bookingclass bookcls = new Bookingclass();
            List<Bookingdata> bookdata = bookcls.GetBookingdetail();
            return View(bookdata);
        }

      
        public ActionResult DeleteFunction(int id)
        {
            if (id != 0)
            {
                AdditionalfacilitiesINFO addi = new AdditionalfacilitiesINFO();
                addi.Deleteadditional(id);
                BookingViewModel bookcls = new BookingViewModel();
                bookcls.DeleteFunctionbyID(id);
            }
            return RedirectToAction("Index", "ReservationEventsmain");

        }
        public ActionResult additionalINFo(int id)
        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            AdditionalfacilitiesINFO addi = new AdditionalfacilitiesINFO();

            List<Bookingdata> book = objforcontext.Bookingdatas.Where(X => X.functionID == id).ToList();
            List<AdditionalFacilitiesandFunction> bookmodellist = objforcontext.AdditionalFacilitiesandFunctions.Where(x => x.functionID.Equals(id)).ToList();

            ViewData["book"] = book;
            return View(bookmodellist);
        }
        public ActionResult additionalINFoprint(int id)
        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            AdditionalfacilitiesINFO addi = new AdditionalfacilitiesINFO();

            List<Bookingdata> book = objforcontext.Bookingdatas.Where(X => X.functionID == id).ToList();
            List<AdditionalFacilitiesandFunction> bookmodellist = objforcontext.AdditionalFacilitiesandFunctions.Where(x => x.functionID.Equals(id)).ToList();

            ViewData["book"] = book;
            return View(bookmodellist);
        }
        public ActionResult EditFunctionGet(int id)
        {
           AddNewFunction custcls = new AddNewFunction();
            Bookingdata cust = custcls.Updatefunction(id);
            return View(cust);

            
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditFunctionGet(EditNewFunction function)
        {
            MehriamarqueeEntities mqe = new MehriamarqueeEntities();
            Bookingdata bookdata = new Bookingdata();
            List<AdditionalFacilitiesandFunction> addi = new List<AdditionalFacilitiesandFunction>();
            addi = mqe.AdditionalFacilitiesandFunctions.Where(X => X.functionID == function.functionID).ToList();
            bookdata.functionID = function.functionID;
            bookdata.bookingDate = function.bookingDate;
            bookdata.functionDate = function.functionDate;
            bookdata.noofGuest = function.noofGuest;
            bookdata.rateperGuest = function.rateperGuest;
            var totalrate = function.noofGuest * function.rateperGuest;
            bookdata.AdvancePayment = function.AdvancePayment;
            bookdata.RemainingPayment = function.RemainingPayment;
            bookdata.Extras = function.Extras;
           
            bookdata.timeShift = function.timeShift;
            bookdata.CnicNo = function.CnicNO;
            bookdata.customerID = function.customerID;
            bookdata.RequestStatus = function.RequestStatus;
            bookdata.MenuId = function.MenuId;

            bookdata.ProgramId = function.ProgramId;
            int totalpriceoffacility = 0;

            foreach(var item in addi)
            {
                totalpriceoffacility = totalpriceoffacility + item.additionalFacilityPrice ?? default(int);
            }





            var fullTotal = totalrate + function.AdvancePayment + function.RemainingPayment + function.Extras+totalpriceoffacility ;
            bookdata.TotalCharges = fullTotal ?? default(int);
            mqe.Entry(bookdata).State = System.Data.Entity.EntityState.Modified;
            mqe.SaveChanges();
            return RedirectToAction("Index", "ReservationEventsmain");
        }

        public ActionResult DeleteAdditional(int id)
        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            AdditionalFacilitiesandFunction addi = new AdditionalFacilitiesandFunction();
            Bookingdata book = new Bookingdata();
            addi = objforcontext.AdditionalFacilitiesandFunctions.Where(x => x.additionalID.Equals(id)).FirstOrDefault();
            book = objforcontext.Bookingdatas.Where(x => x.functionID.Equals(addi.functionID)).FirstOrDefault();

            value = addi.additionalFacilityPrice ?? default(int);
            book.TotalCharges = book.TotalCharges - value;
            objforcontext.Entry(book).State = System.Data.Entity.EntityState.Modified;
            objforcontext.SaveChanges();
            objforcontext.Entry(addi).State = System.Data.Entity.EntityState.Deleted;
            objforcontext.SaveChanges();
            return View("Index");
        }

        public ActionResult EditAdditional(int idofadditional)
        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            AdditionalFacilitiesandFunction addi = new AdditionalFacilitiesandFunction();
            EditAdditionalFacilities edit  = new EditAdditionalFacilities();
            addi = objforcontext.AdditionalFacilitiesandFunctions.Where(x => x.additionalandfunctionID== idofadditional).FirstOrDefault();
           
            return View(addi);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult EditAdditional(EditAdditionalFacilities addfacility)
        {
            MehriamarqueeEntities objforcontext = new MehriamarqueeEntities();
            AdditionalFacilitiesandFunction addi = new AdditionalFacilitiesandFunction();
            Bookingdata book = new Bookingdata();
            book = objforcontext.Bookingdatas.Where(x => x.functionID.Equals(addfacility.functionID)).FirstOrDefault();
            addi=objforcontext.AdditionalFacilitiesandFunctions.Where(x => x.functionID.Equals(addfacility.functionID)).FirstOrDefault();
            value = addi.additionalFacilityPrice ?? default(int);
            book.TotalCharges=book.TotalCharges- value ;
            objforcontext.Entry(book).State = System.Data.Entity.EntityState.Modified;
            objforcontext.SaveChanges();
            addi.additionalandfunctionID = addfacility.additionalandfunctionID;
            addi.additionalID = addfacility.additionalID;
            addi.functionID = addfacility.functionID;
            addi.additionalFacilityPrice = addfacility.additionalFacilityPrice;
            objforcontext.Entry(addi).State = System.Data.Entity.EntityState.Modified;
            objforcontext.SaveChanges();
            book.TotalCharges = book.TotalCharges + addfacility.additionalFacilityPrice ?? default(int);
            objforcontext.Entry(book).State = System.Data.Entity.EntityState.Modified;
            objforcontext.SaveChanges();
            return RedirectToAction("Alldetailoffunction", "ReservationEventsmain");
        }

        public ActionResult HistoryofRequests()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List <Bookingdata> Book = meh.Bookingdatas.Where(X => X.RequestStatus == "true").ToList();
            return View(Book);
        }
    }
}