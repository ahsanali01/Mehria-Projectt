using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AddGeneralJournalClass
    {
        [Display(Name ="Description")][Required(ErrorMessage ="Must be written")][DataType(DataType.MultilineText)]
        public string transactionName { get; set; }
        [Display(Name="Date")][Required(ErrorMessage ="Must be Selected")][DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime transactionDate { get; set; }
        [Display(Name = "Debit/Credit")]
        [Required(ErrorMessage = "Must be Selected")]
        public string Debit_Credit { get; set; }
        [Display(Name = "Amount(Rs:)")]
        [Required(ErrorMessage = "Must be written")]
        public long amount { get; set; }
        public int type { get; set; }
        public int subtype { get; set; }
        public int accountNo { get; set; }
    }
}