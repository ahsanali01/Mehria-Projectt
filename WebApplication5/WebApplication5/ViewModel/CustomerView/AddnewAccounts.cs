using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AddnewAccounts
    {
      [Display(Name ="Account Name")][Required(ErrorMessage ="Please enter Account Name ")]
        public string accountName { get; set; }
        [Display(Name = "Mobile No")]
        [Range(0,99999999999, ErrorMessage = "Limit Exceeded")]
        public Nullable<long> mobileNo { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Description")][DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}