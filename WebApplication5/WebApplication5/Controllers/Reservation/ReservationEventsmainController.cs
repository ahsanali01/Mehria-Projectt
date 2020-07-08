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
    [Authorize]
        public ActionResult Alldetailoffunction()

        {
            MehriamarqueeEntities2 objforcontext = new MehriamarqueeEntities2();
            List<Bookingdata> booklist = objforcontext.Bookingdatas.ToList();
            BookingViewModel bookmodel = new BookingViewModel();
            List<BookingViewModel> bookmodellist = booklist.Select(x => new BookingViewModel
            {
                bookingDate = x.bookingDate,
                functionDate = x.functionDate,
                noofGuest = x.noofGuest,
                rateperGuest = x.rateperGuest,
                stagesCharges = x.stagesCharges,
                basics_others = x.basics_others,
                Extras = x.Extras,
                TotalCharges = x.TotalCharges,
                timeShift = x.timeShift,
                Menuname = x.Menu.menuName,
                ProgramName = x.Program.programName,
                CnicNo = x.CnicNo,
                customerName = x.Customer.customerName,
                Address = x.Customer.address,
                mobileNo = x.Customer.mobileNo,
                remarks = x.Customer.remarks,
                }).ToList();
          
            return View(bookmodellist);
        }

        public ActionResult AdditionalFacilitydetail()
        {
           
            MehriamarqueeEntities2 objforcontext = new MehriamarqueeEntities2();
            AdditionalFacilitiesandFunction additional = objforcontext.AdditionalFacilitiesandFunctions.SingleOrDefault(AdditionalFacilitiesandFunction=>AdditionalFacilitiesandFunction.functionID==1);
            AdditionalfacilitiesINFO additinalmodel = new AdditionalfacilitiesINFO();
            //AdditionalfacilitiesINFO infofacility = ;
            return View();
        }
    }
}