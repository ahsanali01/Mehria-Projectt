using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication5.Models.DB;

namespace WebApplication5.ViewModel.CustomerView
{
    public class BookingViewModel
    {
       public int functionId { get; set; }
     
        public System.DateTime bookingDate { get; set; }
     
        public System.DateTime functionDate { get; set; }
      
        public int noofGuest { get; set; }
      
        public int rateperGuest { get; set; }
       
        public Nullable<int> stagesCharges { get; set; }
       
        public Nullable<int> basics_others { get; set; }

        public int Extras { get; set; }
     
        public int TotalCharges { get; set; }
   
       
        public string timeShift { get; set; }
        public int MenuId { get; set; }
        public int ProgramId { get; set; }
       
        public long CnicNo { get; set; }
       
        public string customerName { get; set; }
       
        public string Address { get; set; }
       
        public long mobileNo { get; set; }
       
      
        public string remarks { get; set; }

        public string Menuname { get; set; }

        public string ProgramName { get; set; }

       
              public void DeleteFunctionbyID(int id)
        {
            Bookingdata book = new Bookingdata { functionID = id };
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
               
               
                    meh.Entry(book).State = System.Data.Entity.EntityState.Deleted;
                    meh.SaveChanges();
                
              
            }
        
    }
    }
}