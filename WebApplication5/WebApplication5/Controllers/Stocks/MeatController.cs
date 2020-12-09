using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper")]
    public class MeatController : Controller
    {
        // GET: Meat
        public ActionResult ViewMeats()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Item> its = new List<Item>();

            its = meh.Items.Where(x => x.category.Equals("Meats")).ToList();
            return View(its);
        }
        public ActionResult EditMeat(int idofitem)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Item its = new Item();

            its = meh.Items.Where(x => x.category == "Meats" && x.itemId == idofitem).FirstOrDefault();
            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult EditMeat(Item it)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            meh.Entry(it).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();


            return RedirectToAction("ViewMeats");
        }
        public ActionResult UpdateMeat(int idofitem)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Item its = new Item();

            its = meh.Items.Where(x => x.category == "Meats" && x.itemId == idofitem).FirstOrDefault();
            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult UpdateMeat(Item it,string UpdatedQuantity)
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

            return RedirectToAction("ViewMeats");
        }
    }
}