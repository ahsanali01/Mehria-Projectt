using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data;
using WebMatrix.WebData;
using System.Web.Security;

namespace WebApplication5
{
     
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializedAuthenticationProcess();
            
           

       


    }

        private void InitializedAuthenticationProcess()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("databasemarque", "Users", "UserId", "UserName", true);
                //WebSecurity.CreateUserAndAccount("Booker", "booked");
                //Roles.CreateRole("Reservator");
              

   
                //WebSecurity.CreateUserAndAccount("Stocker", "Stocked");
                //Roles.CreateRole("Stockkeeper");

                //WebSecurity.CreateUserAndAccount("Accounter", "Accounted");
                //Roles.CreateRole("Accountant");
                //Roles.AddUserToRole("Booker", "Reservator");

                //Roles.AddUserToRole("Stocker", "Stockkeeper");

                //Roles.AddUserToRole("Accounter", "Accountant");



            }
        }
    }
}
