using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models.Accounts
{
    public class GeneralJernal
    {
        [Display(Name ="Date")][Required(ErrorMessage ="Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [Display(Name = "Description")]
 
        public string description { get; set; }

        [Display(Name = "Post Reference")]
        [Required(ErrorMessage = "Post Reference is required")]

        public string postReference { get; set; }

        [Display(Name = "Debit(RS)")]
        [Required(ErrorMessage = "Debit is required")]

        public string debit { get; set; }

        [Display(Name = "Credit(RS)")]
        [Required(ErrorMessage = "Credit is required")]

        public string credit { get; set; }


    }
}