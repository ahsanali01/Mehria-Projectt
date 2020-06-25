using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Accounts
{
    public class GeneralJeneralController : Controller
    {
        // GET: GeneralJeneral
        [Authorize]
        public ActionResult general()
        {
            return View();
        }
    }
}