using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class StockINOUTClass
    {
        public string itemName { get; set; }
        public int salesPrice { get; set; }
        public int purchasePrice { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public string unit { get; set; }
    } 
}