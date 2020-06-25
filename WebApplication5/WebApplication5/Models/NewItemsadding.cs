using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class NewItemsadding
    {
        
           [Display(Name ="Item Name")] [Required(ErrorMessage ="Item Name is Required")] [DataType(DataType.MultilineText)]

            public string itemName { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is Required")]
        [DataType(DataType.MultilineText)]
        public string category { get; set; }
        [Display(Name = "Item Quantity")]
        [Required(ErrorMessage = "Item Quantity is Required")]
        public int itemQuantity { get; set; }
        [Display(Name = "Item Sale Price")]
        [Required(ErrorMessage = "Item Sale Price is Required")]
        public int itemSalePrice { get; set; }
        [Display(Name = "Item Purchase Price")]
        [Required(ErrorMessage = "Item Purchase Price is Required")]
        public int itemPurchasePrice { get; set; }

        
    }
}