using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize]
    public class DesertsController : Controller
    {
        // GET: Deserts
        public ActionResult Index()
        {
            return View();
        }
    }
}