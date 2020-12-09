using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper")]
    public class GroceryController : Controller
    {
        // GET: Grocery
        public ActionResult ViewGrossory()
        {
            
                MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Item> its = new List<Item>();

            its = meh.Items.Where(x => x.category.Equals("Grossory")).ToList();
            return View(its);
        }
        public ActionResult EditGrossory( int idofitem)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Item its = new Item();

            its = meh.Items.Where(x => x.category=="Grossory" && x.itemId== idofitem).FirstOrDefault();
            return View(its);
        }
        [HttpPost,ValidateAntiForgeryToken]

        public ActionResult EditGrossory(Item it)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            meh.Entry(it).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();


            return RedirectToAction("ViewGrossory");
        }
        public ActionResult UpdateGrossory(int idofitem)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Item its = new Item();

            its = meh.Items.Where(x => x.category == "Grossory" && x.itemId == idofitem).FirstOrDefault();
            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult UpdateGrossory(Item it,string UpdatedQuantity)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            it.quantity = it.quantity + int.Parse(UpdatedQuantity);
            meh.Entry(it).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();
            QuantityupdatedItemtable quant = new QuantityupdatedItemtable();
            quant.itemID = it.itemId;
            quant.Date = DateTime.Now;
            quant.Quantity = int.Parse(UpdatedQuantity);
            meh.QuantityupdatedItemtables.Add(quant);
            meh.SaveChanges();

            return RedirectToAction("ViewGrossory");
        }
    }
}