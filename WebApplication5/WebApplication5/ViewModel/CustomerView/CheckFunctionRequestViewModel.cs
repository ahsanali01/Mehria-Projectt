using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class CheckFunctionRequestViewModel
    {
        public int requestID { get; set; }
        public int functionID { get; set; }
        public System.DateTime requestDate { get; set; }
        public System.DateTime bookingDate { get; set; }
        public System.DateTime functionDate { get; set; }
        public int menuID { get; set; }
        public int noofGuests { get; set; }
        public int rateperGuest { get; set; }
        public string menuName { get; set; }
        public string RequestStatus { get; set; }
    }
}