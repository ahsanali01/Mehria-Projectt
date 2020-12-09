using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class StockDesertReportClass
    {
        public int requestID { get; set; }
        public string desertName { get; set; }
        public int PriceDesert { get; set; }
        public int quantityDesert { get; set; }
        public string dishName { get; set; }
    }
}