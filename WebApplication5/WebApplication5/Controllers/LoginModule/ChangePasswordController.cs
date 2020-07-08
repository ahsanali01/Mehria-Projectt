using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebMatrix.WebData;

namespace WebApplication5.Controllers.LoginModule
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        [HttpGet,Authorize]
        public ActionResult passwordchangeforuser()
        {
           
            
          
            return View();
        }
        [HttpPost,Authorize,ValidateAntiForgeryToken]
        public ActionResult passwordchangeforuser(ChnagePasswordModel modelpassword)
        {

            bool ispasswordChnaged = WebSecurity.ChangePassword(WebSecurity.CurrentUserName, modelpassword.oldPassword, modelpassword.newPassword);

            if (ispasswordChnaged)
            {
                return RedirectToAction("Index", "Login");
            }

            else
            {
                ModelState.AddModelError("", "Old Passsword is Incorrect");
            }
            return View();
        }
    }
}