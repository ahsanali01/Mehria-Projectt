﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize]
    public class StocksDetailController : Controller
    {
        // GET: StocksDetail
        public ActionResult Index()
        {
            return View();
        }
    }
}