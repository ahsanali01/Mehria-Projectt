using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    
    public class personalclass
    {
        [Display(Name = "BOOKING DATE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime bookingDate { get; set; }


        [Display(Name = "CNIC NO")]
        public int idNo { get; set; }

        [Display(Name = "CUSTOMER NAME")]
        public string nameOfCustomer { get; set; }

        [Display(Name = "MOBILE NO")][DataType(DataType.PhoneNumber)]
        public int mobileNo { get; set; }


        [Display(Name = "ADDRESS")][DataType(DataType.MultilineText)]
        public string address { get; set; }

        [Display(Name = "REMARKS")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [Display(Name = "MEHNDI")]
        public bool mehndi { get; set; }

        [Display(Name = "NIKAAH")]
        public bool nikah { get; set; }

        [Display(Name = "BAARAT")]
        public bool baarat { get; set; }

        [Display(Name = "WALIMA")]
        public bool walima { get; set; }

        [Display(Name = "PARTY")]
        public bool party { get; set; }



    }
}