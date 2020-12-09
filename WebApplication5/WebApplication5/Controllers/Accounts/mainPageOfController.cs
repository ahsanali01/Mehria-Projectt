using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Accounts
{
    public class mainPageOfController : Controller
    {
        // GET: mainPageOf
        [Authorize(Roles = "Accountant")]
        public ActionResult Index()
        {
            return View();
        }
    }
}