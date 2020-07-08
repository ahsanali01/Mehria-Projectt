using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class GetresetLink
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string username { get; set; }
        [Display(Name = "Email Address(Only gmail)")]
        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
       
    }
}