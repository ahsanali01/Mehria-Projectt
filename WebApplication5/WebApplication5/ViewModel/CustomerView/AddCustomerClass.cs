using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AddCustomerClass
    {


        [Display(Name = "Cnic No")]
        [Required(ErrorMessage = "CNIC NO is required")]
        [Range(0000000000000,9999999999999,ErrorMessage ="Limit Exceeded")]

        public long CnicNo { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        
        public string customerName { get; set; }
        [Range(00000000000,999999999999, ErrorMessage = "Limit Exceeded")]
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile Number is required")]
      
       
        public long mobileNo { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]

       
        [DataType(DataType.MultilineText)]
        public string address { get; set; }
        [Display(Name = "Remarks")]
      
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }
    }
}