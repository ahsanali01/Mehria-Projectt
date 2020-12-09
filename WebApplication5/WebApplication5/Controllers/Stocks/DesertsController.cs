using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper")]
    public class DesertsController : Controller
    {
        // GET: Deserts
        public ActionResult ViewDeserts()
        {
            
                     MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Desert> its = new List<Desert>();

            its = meh.Deserts.ToList();
            return View(its);
        }

        public ActionResult EditDeserts(int idofDese)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Desert its = new Desert();
            its = meh.Deserts.Where(X => X.desertId == idofDese).FirstOrDefault();
           
            return View(its);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult EditDeserts(Desert de)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            meh.Entry(de).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();


            return RedirectToAction("ViewDeserts");
        }

        public ActionResult UpdateDeserts(int idofDese)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            Desert its = new Desert();
            its = meh.Deserts.Where(X => X.desertId == idofDese).FirstOrDefault();

            return View(its);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateDeserts(Desert de,string UpdatedQuantity)
        {

            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            de.quantityOfdesert = de.quantityOfdesert + int.Parse(UpdatedQuantity);
            meh.Entry(de).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();
            QuantityupdatedDeserttable quant = new QuantityupdatedDeserttable();
            quant.desertID = de.desertId;
            quant.Date = DateTime.Now;
            quant.Quantity = int.Parse(UpdatedQuantity);
            meh.QuantityupdatedDeserttables.Add(quant);
            meh.SaveChanges();


            return RedirectToAction("ViewDeserts");
        }

    }
}