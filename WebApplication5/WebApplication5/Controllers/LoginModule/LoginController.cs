using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WebApplication5.Models;
using WebMatrix.WebData;


namespace WebApplication5.Controllers
{
    
    public class LoginController : Controller
    {
      
        // GET: Login
     
        public ActionResult MainPageofIndex(ModelofLogin login1)
        {

            if (ModelState.IsValid)
            {
                bool isAuthenticated = WebSecurity.Login(login1.Username, login1.Password, login1.Rememberme);
                string userexist = WebSecurity.CurrentUserName;
                if (isAuthenticated && login1.Username == "Booker")
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
                    TempData["message"] = " Username or Password is Incorrect";
                    ModelState.AddModelError("", "Username or Password is Incorrect");
                       // return PartialView("ReservationLogin()");
                  
                  //  return PartialView("ReservationLogin",login1); 


                }




            }

            return View();
        }
   
        [HttpGet]
        public ActionResult ReservationLogin()
        {
            return View();
        }
      
        public ActionResult StockLogin() { 
       

            return View();
        }
       
    

        public ActionResult AccountLogin(ModelofLogin login1)
        {

           


            

            return View();
        }
        [HttpGet]
        public ActionResult ResetLinkforPassword()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult ResetLinkforPassword(GetresetLink link,string token)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.UserExists(link.username))
                {
                    
                     token = WebSecurity.GeneratePasswordResetToken(link.username);


                    if (token == null)
                    {
                        // If user does not exist or is not confirmed.  
                        ModelState.AddModelError("", "Username does not exisit");
                        return RedirectToAction("MainPageofIndex", "Login");

                    }
                    else
                    {
                        //Create URL with above token  
                        try {
                            string To = link.EmailAddress;
                            string Subject = "Get token ";
                            string body = token;
                            MailMessage mail = new MailMessage();
                            mail.To.Add(link.EmailAddress);
                            mail.From = new MailAddress("Codepub8@gmail.com");
                            mail.Subject = Subject;
                            mail.Body = "This is your token = " + body + "\nEnter this token into given filed and add new password successfully";

                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 25;
                            smtp.UseDefaultCredentials = false;
                            smtp.EnableSsl = true;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential("Codepub8@gmail.com", "Mehria@123");
                            smtp.Send(mail);

                            TempData["mydata"] = token;
                            TempData["message"] = "Token sended successfully To:" + link.EmailAddress;
                            return RedirectToAction("GetPasswordform", "PasswordReset");

                        }
                        catch (Exception)
                        {
                            TempData["message"] = "!Incorrect Email Address";
                        }
                        }
                }
                else
                {
                    ModelState.AddModelError("", "Username does not exisit please enter valid username");
                }
            }

          
            return View();
        }

      

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Clear();
            WebSecurity.Logout();

            return RedirectToAction("MainPageofIndex", "Login");
        }

        
        public ActionResult check()
        {
            if (WebSecurity.CurrentUserName == "Booker")
            {
                return RedirectToAction("Index", "ReservationEventsmain");
            }
            else if (WebSecurity.CurrentUserName == "Stocker") {
                return RedirectToAction("Index", "StocksDetail");
            }

            else if(WebSecurity.CurrentUserName == "Accounter")
            {
                return RedirectToAction("Index", "mainPageOf");
            }

            else
            {
                return RedirectToAction("MainPageofIndex", "Login");
            }

            
        }

        public ActionResult AboutUs()
        {
           

            return View();
        }
        public ActionResult PrivacyPolicy()
        {


            return View();
        }
        public ActionResult ContactUS()
        {


            return View();
        }

    }
}