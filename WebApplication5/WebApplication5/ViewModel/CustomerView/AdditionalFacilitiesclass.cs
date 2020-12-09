using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    [System.Web.UI.ControlValueProperty("SelectedDate", typeof(System.DateTime), "1/1/0001")]
    public class AdditionalFacilitiesclass
    {
        public int functionId { get; set; }
        public int facilitiesId { get; set; }
        public string facilitiesName { get; set; }
        public int Price { get; set; }
        public bool Isavalaible { get; set; }

        
    }
}