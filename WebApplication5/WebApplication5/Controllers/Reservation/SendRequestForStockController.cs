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
        [Authorize(Roles = "Reservator")]
        // GET: SendRequestForStock
        public ActionResult Index()

        {
           // int countval = 0;
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
           
          //  List<FunctionRequestedTable> func = meh.FunctionRequestedTables.ToList();
            //foreach(var item in func)
            //{
            //    ViewBag.funcID = item.functionID;
            //  //  countval++;
            //}
           // ViewData["func"] = func;
           // ViewBag.countval = countval;
            List<Bookingdata> bookdata = meh.Bookingdatas.Where(X=>X.RequestStatus=="false").ToList();
            return View(bookdata);
           
        }
        public ActionResult FreeSlot()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Bookingdata> book = meh.Bookingdatas.ToList();
            List<int> date = new List<int>();
            List<int> year = new List<int>();
            List<int> month = new List<int>();
            foreach (var item in book)
            {
                date.Add(item.functionDate.Day);
                year.Add(item.functionDate.Year);
                month.Add(item.functionDate.Month);
            }
            ViewBag.date = date;
            ViewBag.year = year;
            ViewBag.month = month;
            return View();
        }
     
        public ActionResult RequestFunction (int ID)
        {

           
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Bookingdata book =meh.Bookingdatas.Where(X=>X.functionID==ID).FirstOrDefault() ;
            book.RequestStatus = "true";
            meh.Entry(book).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();
            FunctionRequestedTable   funcls = new FunctionRequestedTable();
            funcls.functionID = ID;
            funcls.requestDate = DateTime.Today;
            funcls.Status = "SENDED";
            meh.FunctionRequestedTables.Add(funcls);
            meh.SaveChanges();

            return RedirectToAction("Index");
         
           
            }
           
        }
    }
