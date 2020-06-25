using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication5.Models
{
    public class BookingDetail
    {
      
       
        [Display(Name = "Function Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Function Occurans Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FunctionOccuransDate { get; set; }
        [Display(Name = "No of Guest")] 
        [Required(AllowEmptyStrings = false, ErrorMessage = "No Of Guests is Required")]
        public int noOfGuest { get; set; }
        [Display(Name = "Rate Per Guest")]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Rate Per Guest is Required")]
        public int ratePerGuest { get; set; }
        [Display(Name = "Stages Charges")]
        [DataType(DataType.Currency)]
        public int stagescharges { get; set; }
        [Display(Name = "Advance Payment")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Advance Payment is Required")]
        [DataType(DataType.Currency)]
        public int basicsOthers { get; set; }
        [Display(Name = "Remaining Payment")]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Remaining Payment is Required")]
        public int Extras { get; set; }
        [Display(Name = "Total Charges")]
        [DataType(DataType.Currency)]

        public int TotalCharges { get; set; }
     
        public string timeShift { get; set; }

        [Display(Name = "Night")]
        public string timeShift2 { get; set; }
        
        [Display(Name = "Function Type")]
     
        public string programId { get; set; }
        [Display(Name = "Selected Menu")]
        public string menuID { get; set; }
       

    }
}