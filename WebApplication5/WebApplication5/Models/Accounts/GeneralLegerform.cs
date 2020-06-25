using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models.Accounts
{
    public class GeneralLegerform
    {
        [Display(Name ="Accounts")][Required(ErrorMessage ="Accounts is required")]
        public string accounts { get; set; }
        [Display(Name = "From Date")]
        [Required(ErrorMessage = "From Date is required")]
        public string fromDate { get; set; }
        [Display(Name = "To Date")]
        [Required(ErrorMessage = "To Date is required")]
        public string toDate { get; set; }

       
    }
}