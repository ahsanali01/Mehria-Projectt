using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebMatrix.WebData;

namespace WebApplication5.Controllers.LoginModule
{
    public class PasswordResetController : Controller
    {

        // GET: PasswordReset
        [HttpGet]
        public ActionResult GetPasswordform()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult GetPasswordform(Passwordresetmodel reset)
        {
            
            if (reset.username == "Stocker" || reset.username == "Booker")
            {
                var result = WebSecurity.GeneratePasswordResetToken(reset.username, 1440);

                WebSecurity.ResetPassword(result, reset.newPassword);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "username is incorrect Please enter valid username");
            }
            return View();
        }
    }
}