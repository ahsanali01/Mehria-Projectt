using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AddNewFunction
    {

        [Display(Name ="Booking Date")]
        [Required(ErrorMessage ="Booking Date must be Selected")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime bookingDate { get; set; }
        [Display(Name = "Function Date")]
        [Required(ErrorMessage = "Function Date must be Selected")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime functionDate { get; set; }
        [Display(Name = "No Of Guests")]
        [Required(ErrorMessage = "Please enter Number of Guests")]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]

        public int noofGuest { get; set; }
        [Display(Name = "Rate Per Guests")]
        [Required(ErrorMessage = "Please enter Rate Per Guest")]
        [DataType(DataType.Currency)]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        public int rateperGuest { get; set; }
        [Display(Name = "Stage Charges")]
        [Required(ErrorMessage = "Please enter Stage Charges")]
        [DataType(DataType.Currency)]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        public Nullable<int> stagesCharges { get; set; }
        [Display(Name = "Basics Other")]
        [Required(ErrorMessage = "Please enter Basics Other")]
        [DataType(DataType.Currency)]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        public int basics_others { get; set; }
        [Display(Name = "Extras")]
        [Required(ErrorMessage = "Please enter Extra Charges")]
        [DataType(DataType.Currency)]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        public int Extras { get; set; }
        [Display(Name = "Total Charges")]
        [Required(ErrorMessage = "Please enter Total Charges")]
        [DataType(DataType.Currency)]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        public int TotalCharges { get; set; }
         
      
        [Display(Name = "Shift(Day/Night)")]
        [Required(ErrorMessage = "Shift must be Selected")]

        public string timeShift { get; set; }
        public int MenuId { get; set; }
        public int ProgramId { get; set; }
        [Display(Name = "CNIC NO")]
        [Required(ErrorMessage = "Please enter Same Customer CNIC NO Here")]
        [DataType(DataType.CreditCard)]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        public string CnicNo { get; set; }
        

    }
}