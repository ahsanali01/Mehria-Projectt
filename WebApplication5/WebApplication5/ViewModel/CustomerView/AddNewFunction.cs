using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication5.Models.DB;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AddNewFunction
    {

        [Display(Name ="Booking Date")]
        [Required(ErrorMessage ="Booking Date must be Selected")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime bookingDate { get; set; }
        [Display(Name = "Function Date")]
        [Required(ErrorMessage = "Function Date must be Selected")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime functionDate { get; set; }
        [Display(Name = "No Of Guests")]
        [Required(ErrorMessage = "Please enter Number of Guests")]
     

        public int noofGuest { get; set; }
        [Display(Name = "Rate Per Guests")]
        [Required(ErrorMessage = "Please enter Rate Per Guest")]
       
     
        public int rateperGuest { get; set; }
        [Display(Name = "Advance Payment")]
        [Required(ErrorMessage = "Please enter Advance Payment")]
      
       
        public Nullable<int> AdvancePayment { get; set; }
        [Display(Name = "Remaining Payment")]
        [Required(ErrorMessage = "Please enter Remaining Payment")]
   
  
        public Nullable<int> RemainingPayment { get; set; }
        [Display(Name = "Extras")]
        [Required(ErrorMessage = "Please enter Extra Charges")]
   
 
        public int Extras { get; set; }
        [Display(Name = "Total Charges")]
        [Required(ErrorMessage = "Please enter Total Charges")]
  
     
        public int TotalCharges { get; set; }
         
      
        [Display(Name = "Shift(Day/Night)")]
        [Required(ErrorMessage = "Shift must be Selected")]

        public string timeShift { get; set; }
        public int MenuId { get; set; }

      
        public int ProgramId { get; set; }
        [Display(Name = "CNIC NO")]
        [Required(ErrorMessage = "Please enter Same Customer CNIC NO Here")]
     
        [Range(0, Int64.MaxValue, ErrorMessage = "Please enter valid Number")]
        public long CnicNo { get; set; }
        
        public Nullable<int> stagePrice { get; set; }
        public Nullable<int>  DjPrice { get; set; }
        public Nullable<int> electriccityPrice { get; set; }
        public Nullable<int> AcHeatingPrice { get; set; }
       
        public Nullable<int> FullHallPrice { get; set; }

        public Bookingdata Updatefunction(int id)
        {
            Bookingdata cust = new Bookingdata();
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                cust = meh.Bookingdatas.Where(X => X.functionID== id).FirstOrDefault();
            }
            return cust;
        }
    }
}