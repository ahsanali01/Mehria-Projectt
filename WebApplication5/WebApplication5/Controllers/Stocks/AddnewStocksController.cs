using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper")]
    public class AddnewStocksController : Controller
    {
        // GET: AddnewStocks

        public ActionResult addNewStocksGet()
        {
            var Categorylist = new SelectList(new[]
{
    new { ID = "Beverages", Name = "Beverages" },
    new { ID = "Deserts", Name = "Deserts"},
    new { ID = "Vegetable", Name = "Vegetable"},
    new {ID="Meats",Name="Meats"},
   new {ID="Grossory", Name="Grocery" }
},
"ID", "Name");

            ViewData["Categorylist"] = Categorylist;

            var Unitlist = new SelectList(new[]
{
    new { ID = "Kgs", Name = "Kgs" },
    new { ID = "Gram", Name = "Gram"},
    new { ID = "500Gram", Name = "500 Gram"},
    new {ID="three/Quatar",Name="three/Quatar"},
   new {ID="None", Name="None" }
}, "ID", "Name");

            ViewData["Unitlist"] = Unitlist;
            return View();
        }

        public ActionResult addNewStocksPost(NewItemsadding add, string Categorylist, string Unitlist)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            try
            {
                if (Categorylist == "Vegetable")
                {

                    Item it = new Item();
                    it.itemName = add.itemName;
                    it.quantity = add.itemQuantity;
                    it.salesPrice = add.itemSalePrice;
                    it.purchasePrice = add.itemPurchasePrice;
                    it.category = Categorylist;
                    it.unit = Unitlist;
                    meh.Items.Add(it);
                    meh.SaveChanges();
                    QuantityupdatedItemtable quant = new QuantityupdatedItemtable();
                    quant.itemID = it.itemId;
                    quant.Date = DateTime.Today;
                    quant.Quantity = it.quantity;
                    meh.QuantityupdatedItemtables.Add(quant);
                    meh.SaveChanges();
                    TempData["message"] = "Stock Added Successfully";
                }




                if (Categorylist == "Meats")
                {

                    Item it = new Item();
                    it.itemName = add.itemName;
                    it.quantity = add.itemQuantity;
                    it.salesPrice = add.itemSalePrice;
                    it.purchasePrice = add.itemPurchasePrice;
                    it.category = Categorylist;
                    it.unit = Unitlist;
                    meh.Items.Add(it);
                    meh.SaveChanges();
                    QuantityupdatedItemtable quant = new QuantityupdatedItemtable();
                    quant.itemID = it.itemId;
                    quant.Date = DateTime.Today;
                    quant.Quantity = it.quantity;
                    meh.QuantityupdatedItemtables.Add(quant);
                    meh.SaveChanges();
                    TempData["message"] = "Stock Added Successfully";
                }




                if (Categorylist == "Grossory")
                {

                    Item it = new Item();
                    it.itemName = add.itemName;
                    it.quantity = add.itemQuantity;
                    it.salesPrice = add.itemSalePrice;
                    it.purchasePrice = add.itemPurchasePrice;
                    it.category = Categorylist;
                    it.unit = Unitlist;
                    meh.Items.Add(it);
                    meh.SaveChanges();
                    QuantityupdatedItemtable quant = new QuantityupdatedItemtable();
                    quant.itemID = it.itemId;
                    quant.Date = DateTime.Today;
                    quant.Quantity = it.quantity;
                    meh.QuantityupdatedItemtables.Add(quant);
                    meh.SaveChanges();
                    TempData["message"] = "Stock Added Successfully";
                }




                if (Categorylist == "Beverages")
                {

                    Beverage beverage = new Beverage();
                    beverage.beveragesName = add.itemName;
                    beverage.quantityOfBeverages = add.itemQuantity;
                    beverage.beveragesSalePrice = add.itemSalePrice;
                    beverage.beveragesPurchasePrice = add.itemPurchasePrice;

                    meh.Beverages.Add(beverage);
                    meh.SaveChanges();
                    QuantityupdateBeveragestable quant = new QuantityupdateBeveragestable();
                    quant.beverageID = beverage.beverageId;
                    quant.Date = DateTime.Today;
                    quant.Quantity = beverage.quantityOfBeverages;
                    meh.QuantityupdateBeveragestables.Add(quant);
                    meh.SaveChanges();
                    TempData["message"] = "Stock Added Successfully";

                }
                if (Categorylist == "Deserts")
                {

                    Desert desert = new Desert();
                    desert.desertName = add.itemName;
                    desert.quantityOfdesert = add.itemQuantity;
                    desert.desertSalePrice = add.itemSalePrice;
                    desert.desertPurchasePrice = add.itemPurchasePrice;

                    meh.Deserts.Add(desert);
                    meh.SaveChanges();
                    QuantityupdatedDeserttable quant = new QuantityupdatedDeserttable();
                    quant.desertID = desert.desertId;
                    quant.Date = DateTime.Today;
                    quant.Quantity = desert.quantityOfdesert;
                    meh.QuantityupdatedDeserttables.Add(quant);
                    meh.SaveChanges();
                    TempData["message"] = "Stock Added Successfully";
                }
            }
            catch (Exception)
            {
                TempData["message"] = "Server problem !Try Again";
            }
        
            return RedirectToAction("addNewStocksGet");
    }
    }
}