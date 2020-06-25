using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Passwordresetmodel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string username { get; set; }
        [Display(Name = "New Password")]
        [Required(ErrorMessage = "new Password is required")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm new Password is required")][Compare("newPassword")]
        public string confirmnewPassword { get; set; }
    }
}