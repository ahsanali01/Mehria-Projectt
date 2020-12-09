using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class EditAdditionalFacilities
    {
        public int additionalandfunctionID { get; set; }
        public int functionID { get; set; }
        public int additionalID { get; set; }
        public Nullable<int> additionalFacilityPrice { get; set; }
    }
}