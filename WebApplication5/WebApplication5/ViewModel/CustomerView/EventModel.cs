using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class EventModel
    {
        
            [Display(Name = "Enter Date")][DataType(DataType.Date)]
            public DateTime? EnterDate { get; set; }
        
    }
}