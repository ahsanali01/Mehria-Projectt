using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class StockItemReportClass
    {
        public int requestID { get; set; }
        public string itemName { get; set; }
        public int qunatityOfItems { get; set; }
        public int priceOfItems { get; set; }
        public string dishName { get; set; }
    }
}