using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class EditNewFunction
    {
        public int functionID { get; set; }
        public System.DateTime bookingDate { get; set; }
        public System.DateTime functionDate { get; set; }
        public int noofGuest { get; set; }
        public int rateperGuest { get; set; }
        public Nullable<int> AdvancePayment { get; set; }
        public Nullable<int> RemainingPayment { get; set; }
        public int Extras { get; set; }
        public int TotalCharges { get; set; }
        public string timeShift { get; set; }
        public int MenuId { get; set; }
        public int ProgramId { get; set; }
        public long CnicNO { get; set; }
        public int customerID { get; set; }
        public string RequestStatus { get; set; }
    }
}