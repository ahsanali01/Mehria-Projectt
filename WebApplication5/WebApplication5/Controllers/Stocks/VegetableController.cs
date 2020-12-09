using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper")]
    public class VegetableController : Controller
    {
        // GET: Vegetable
        public ActionResult ViewVegetable()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Item> its = new List<Item>();
            
            its = meh.Items.Where(x => x.category.Equals("Vegetable")).ToList();
            return View(its);
        }
        public ActionResult EditVegetable(int idofitem)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Item its = new Item();

            its = meh.Items.Where(x => x.category == "Vegetable" && x.itemId == idofitem).FirstOrDefault();
            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult EditVegetable(Item it)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            meh.Entry(it).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();


            return RedirectToAction("ViewVegetable");
        }
        public ActionResult UpdateVegetable(int idofitem)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Item its = new Item();

            its = meh.Items.Where(x => x.category == "Vegetable" && x.itemId == idofitem).FirstOrDefault();
            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult UpdateVegetable(Item it,string UpdatedQuantity)
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
            return RedirectToAction("ViewVegetable");
        }
    }
}