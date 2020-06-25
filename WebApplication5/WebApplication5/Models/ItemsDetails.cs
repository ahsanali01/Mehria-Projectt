using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ItemsDetails

    {
        public int itemId { get; set; }

        public string itemName { get; set; }

        public int itemQuantity { get; set; }
        public int itemSalePrice { get; set; }
        public int itemPurchasePrice { get; set; }

    }
}