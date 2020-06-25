using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models.DB;

namespace WebApplication5.ViewModel.CustomerView
{
    public class CustomerClass
    {
        public List<Customer> GetCustomers()
        {
            List<Customer> Custmer = new List<Customer>();
            using (MehriamarqueeEntities2 db = new MehriamarqueeEntities2())
            {
                Custmer= db.Customers.ToList();
            }
            return Custmer;
        }
    }
}