using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models.Accounts
{
    public class ListofVoucherdetail
    {
        [Display(Name = "Voucher Date")]
        [Required(ErrorMessage = "Voucher Date is Required")]
        public string voucherDate { get; set; }

        [Display(Name = "Voucher No")]
        [Required(ErrorMessage = "Voucher No is Required")]
        public string VoucherNo { get; set; }

        [Display(Name = "Narration")]
        [Required(ErrorMessage = "Voucher No is Required")]
        public string narration { get; set; }
    }
}