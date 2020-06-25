using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebMatrix.WebData;


namespace WebApplication5.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index(ModelofLogin login1)
        {

            if (ModelState.IsValid)
            {
                bool isAuthenticated = WebSecurity.Login(login1.Username, login1.Password, login1.Rememberme);
                string userexist = WebSecurity.CurrentUserName;
                if (isAuthenticated && userexist == "Booker")
                {
                    return RedirectToAction("Index", "ReservationEventsmain");

                }

                else if (isAuthenticated && login1.Username == "Stocker")
                {
                    return RedirectToAction("Index", "StocksDetail");
                }
                else if (isAuthenticated && login1.Username == "Accounter")
                {
                    return RedirectToAction("Index", "mainPageOf");
                }
                else
                {

                    ModelState.AddModelError("", "Username or Password is Incorrect");
                }




            }

            return View();
        }
      
        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Clear();
            WebSecurity.Logout();
            
            return RedirectToAction("Index", "Login");
        }

      
    }
}