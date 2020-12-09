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
            using (MehriamarqueeEntities db = new MehriamarqueeEntities())
            {
                Custmer = db.Customers.ToList();
            }
            return Custmer;
        }

        public List<Customer> FindCustomer(long searchterm)
        {
            
            List<Customer> custmer = new List<Customer>();
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                custmer = meh.Customers.Where(X => X.CnicNo.Equals(searchterm)).ToList();
            }
            return custmer;
        }

   

        public Customer UpdateCustomer(long id)
        {
            Customer cust = new Customer();
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                cust = meh.Customers.Where(X => X.customerID == id).FirstOrDefault();
            }
            return cust;
        }

        public void UpdateCustomerSave(Customer cus)
        {
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                meh.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                meh.SaveChanges();
            }
        }

        public void DeleteCustomerbyID(long id)
        {
            Customer cus = new Customer();
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                cus = meh.Customers.Where(X => X.customerID== id).FirstOrDefault();
                meh.Entry(cus).State = System.Data.Entity.EntityState.Deleted;
                meh.SaveChanges();
            }
        }
    }
}