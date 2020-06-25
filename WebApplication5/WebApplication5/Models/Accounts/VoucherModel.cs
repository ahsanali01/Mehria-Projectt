using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models.Accounts
{
    public class VoucherModel
    {
        [Display(Name ="Voucher Type")]
        public string voucherType { get; set; }
        [Display(Name = "Voucher No")][Required(ErrorMessage ="Voucher No is Required")]
        public string VoucherNo { get; set; }

        [Display(Name = "Narration")]
        [Required(ErrorMessage = "Voucher No is Required")]
        public string narration { get; set; }
        [Display(Name = "Voucher Date")]
        [Required(ErrorMessage = "Voucher Date is Required")]
        public string voucherDate { get; set; }
        [Display(Name = "Payee/Payer")]
        [Required(ErrorMessage = "Payee/Payer is Required")]
        public string payee_payer { get; set; }
        [Display(Name = "Accounts")]
        public string account { get; set; }
        [Display(Name = "BILL#")]
        [Required(ErrorMessage = "BILL No is Required")]
        public string billNo { get; set; }
        [Display(Name = "Cheque No")]
        [Required(ErrorMessage = "Cheque No is Required")]
        public string chqNo { get; set; }
        [Display(Name = "Cheque Date")]
        [Required(ErrorMessage = "Cheque Date is Required")]
        public string chqDate { get; set; }
        [Display(Name = "Debit(RS)")]
        [Required(ErrorMessage = "Debit(RS) is Required")]
        public string debit { get; set; }
        [Display(Name = "Credit(RS)")]
        [Required(ErrorMessage = "Credit(RS) is Required")]
        public string credit { get; set; }
        [Display(Name = "Events")]
        
        public string Event { get; set; }





    }
}