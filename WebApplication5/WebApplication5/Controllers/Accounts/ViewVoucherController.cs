using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Accounts
{
    public class ViewVoucherController : Controller
    {
        // GET: View
        [Authorize]
        public ActionResult Searchdetail()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListDetail()
        {
            return View();
        }
    }
}