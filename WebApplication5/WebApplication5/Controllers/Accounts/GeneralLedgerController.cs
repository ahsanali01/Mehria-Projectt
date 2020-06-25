using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Accounts
{
    public class GeneralLedgerController : Controller
    {
        // GET: GeneralLedger
        [Authorize]
        public ActionResult Creategeneralledger()
        {
            return View();
        }
    }
}