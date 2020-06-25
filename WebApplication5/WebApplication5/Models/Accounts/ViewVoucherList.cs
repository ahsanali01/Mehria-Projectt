using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models.Accounts
{
    public class ViewVoucherEnterForm
    {
        [Display(Name = "Search")]
        public string search { get; set; }
        [Display(Name = "Voucher Type")]
        public string voucherType { get; set; }
        [Display(Name = "Voucher ID")]
        [Required(ErrorMessage = "Voucher No is Required")]
        public string VoucherNo { get; set; }

        [Display(Name = "From Date")]
        [Required(ErrorMessage = "Voucher No is Required")]
        public string fromDate { get; set; }
        [Display(Name = "To Date")]
        [Required(ErrorMessage = "Voucher Date is Required")]

        public string ToDate { get; set; }
    }
}