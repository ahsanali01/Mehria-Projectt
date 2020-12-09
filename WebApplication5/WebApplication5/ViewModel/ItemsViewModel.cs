using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel
{
    public class ItemsViewModel
    {
        public string itemName { get; set; }
        public int salesPrice { get; set; }
        public int purchasePrice { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public string unit { get; set; }
    }
}