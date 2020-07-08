using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AddCustomerClass
    {
        [Display(Name ="CNIC No")][Required(ErrorMessage ="CNIC is required")][RegularExpression("int",ErrorMessage =(" Must be Number "))]
        public string CnicNo { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        
        public string customerName { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string mobileNo { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Mobile No is required")]
        [RegularExpression("int", ErrorMessage = (" Must be Number "))]
        [DataType(DataType.MultilineText)]
        public string address { get; set; }
        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Remarks is required")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }
    }
}