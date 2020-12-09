
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper")]
    public class BerveragesController : Controller
    {
       
        // GET: Berverages
        public ActionResult ViewBeverages()
        {


            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Beverage> its = new List<Beverage>();

            its = meh.Beverages.ToList();
            return View(its);
        }

        public ActionResult EditBeverages(int idofbeve)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Beverage its = new Beverage();
            its = meh.Beverages.Where(X => X.beverageId == idofbeve).FirstOrDefault();
            return View(its);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult EditBeverages(Beverage beve)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            meh.Entry(beve).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();
            return RedirectToAction("ViewBeverages");

        }
        public ActionResult UpdateBeverages(int idofbeve)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Beverage its = new Beverage();
            its = meh.Beverages.Where(X => X.beverageId == idofbeve).FirstOrDefault();
           
            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateBeverages(Beverage beve,string UpdatedQuantity)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            beve.quantityOfBeverages = beve.quantityOfBeverages + int.Parse(UpdatedQuantity);
                meh.Entry(beve).State = System.Data.Entity.EntityState.Modified;
                meh.SaveChanges();
          
            QuantityupdateBeveragestable quant = new QuantityupdateBeveragestable();
            quant.beverageID = beve.beverageId;
            quant.Date = DateTime.Now;
            quant.Quantity = int.Parse(UpdatedQuantity);
            meh.QuantityupdateBeveragestables.Add(quant);
            meh.SaveChanges();
            return RedirectToAction("ViewBeverages");

        }
    }
    }