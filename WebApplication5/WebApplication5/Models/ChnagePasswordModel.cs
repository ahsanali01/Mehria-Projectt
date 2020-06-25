using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ChnagePasswordModel
    {
        [Display(Name ="Old Password")]
        [Required(ErrorMessage ="Old Password is required")]
        public string oldPassword { get; set; }
        [Display(Name = "New Password")][DataType(DataType.Password)]
        [Required(ErrorMessage = "new Password is required")]
        public string newPassword { get; set; }
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)][Compare("newPassword")]
        [Required(ErrorMessage = "Confirm new Password is required")]
        public string confirmnewPassword { get; set; }
    }
}