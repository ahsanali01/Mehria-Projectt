using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Accounts
{
    public class VoucherController : Controller
    {
        // GET: Voucher
        [Authorize]
        public ActionResult Index()
        {
         


            return View();
        }

       

      
    }
}