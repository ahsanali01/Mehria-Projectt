using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Accounts
{
    [Authorize(Roles = "Accountant")]
    public class AccountsReportController : Controller
    {
        // GET: Voucher
        [Authorize]
        public ActionResult Index()
        {
         


            return View();
        }


        public ActionResult AccountReceivable()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AccountReceivable(DateTime FromDate, DateTime ToDate)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            long creditbalance=0;
            long debitblance = 0;
            long totaaccountreceivable = 0;

            List<SubAccountBalance> accountreceivable = meh.SubAccountBalances.Where(X => X.subID == 12 && X.Date >= FromDate && X.Date <= ToDate).ToList();

            foreach (var i in accountreceivable)
            {


                if (i.Credit != 0)
                {

                    creditbalance = creditbalance + i.Credit;
                }
                else
                {
                    debitblance = debitblance + i.Debit;
                }

            }
           
                totaaccountreceivable = creditbalance - debitblance;

            


            ViewBag.totaaccountreceivable = totaaccountreceivable;


            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            return View();
        }



        public ActionResult AccountPayable()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AccountPayable(DateTime FromDate, DateTime ToDate)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            long creditbalance = 0;
            long debitblance = 0;
            long totaaccountpayable = 0;

            List<SubAccountBalance> accountpayable = meh.SubAccountBalances.Where(X => X.subID == 16 && X.Date >= FromDate && X.Date <= ToDate).ToList();

            foreach (var i in accountpayable)
            {


                if (i.Credit != 0)
                {

                    creditbalance = creditbalance + i.Credit;
                }
                else
                {
                    debitblance = debitblance + i.Debit;
                }

            }

                totaaccountpayable = creditbalance - debitblance;

            


            ViewBag.totaaccountpayable = totaaccountpayable;


            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            return View();
        }


    }
}