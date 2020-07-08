using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class BookingViewModel
    {
       
     
        public System.DateTime bookingDate { get; set; }
     
        public System.DateTime functionDate { get; set; }
      
        public int noofGuest { get; set; }
      
        public int rateperGuest { get; set; }
       
        public Nullable<int> stagesCharges { get; set; }
       
        public int basics_others { get; set; }

        public int Extras { get; set; }
     
        public int TotalCharges { get; set; }
   
       
        public string timeShift { get; set; }
        public int MenuId { get; set; }
        public int ProgramId { get; set; }
       
        public string CnicNo { get; set; }
       
        public string customerName { get; set; }
       
        public string Address { get; set; }
       
        public string mobileNo { get; set; }
       
      
        public string remarks { get; set; }

        public string Menuname { get; set; }

        public string ProgramName { get; set; }
      
    }
}