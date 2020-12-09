using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles="Stockkeeper")]
    public class StocksDetailController : Controller
    {
        // GET: StocksDetail
        public ActionResult Index()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            var totalrequests = meh.FunctionRequestedTables.Where(x => x.Status == "SENDED").Count();
            ViewBag.totalrequests = totalrequests;


            return View();
        }

        public ActionResult CheckFunctionRequest()
        {

            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {

                List<FunctionRequestedTable> request = meh.FunctionRequestedTables.ToList();
                List<CheckFunctionRequestViewModel> Requestlist = new List<CheckFunctionRequestViewModel>();

                List<CheckFunctionRequestViewModel> Request = request.Select(X => new CheckFunctionRequestViewModel
                {   requestID=X.requestID,
                    functionID = X.functionID,
                    requestDate = X.requestDate,
                    bookingDate = X.Bookingdata.bookingDate,
                    functionDate = X.Bookingdata.functionDate,
                    noofGuests = X.Bookingdata.noofGuest,
                    rateperGuest = X.Bookingdata.rateperGuest,
                    menuID = X.Bookingdata.MenuId,
                    menuName = X.Bookingdata.Menu.menuName,
                   RequestStatus=X.Status
                }).ToList();

                var Model = new NameofItem();
             

                return View(Request);
            }
        }

        public ActionResult AddItemsForDish(int IDofdish,int requestedID)
        {
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                List<MenuWithDish> mn = meh.MenuWithDishes.ToList();
                List<NameofItem> Viewdish = new List<NameofItem>();
                List<NameofItem> viewDish = mn.Select(X => new NameofItem
                {
                    dishID = X.dishID,
                    dishName = X.Dish.dishName,
                    menuID = X.menuID
                }).ToList();

                ViewBag.IDofdish = IDofdish;
                ViewBag.requestedID = requestedID;
                ViewData["ItemNames"] = meh.Items.ToList();

                ViewData["BevergeName"] = meh.Beverages.ToList();

                ViewData["DesertName"] = meh.Deserts.ToList();

                return View(viewDish);

            }


        }
        [HttpPost]
        public ActionResult GetItemsForDish(List<string> items, List<string> Beve, List<string> Desert,int idofrequest)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<Item> itemes = meh.Items.ToList();
            List<Beverage> Beveitems = meh.Beverages.ToList();
            List<Desert> Desetitems = meh.Deserts.ToList();
            List<Dish> dihes = meh.Dishes.ToList();
            for (int i=0; i<items.Count; i++)
            {
             
                foreach (var itemcoun in dihes)
                {
                    if (items[i] == itemcoun.dishName)
                    {
                        
                            foreach (var getitems in itemes)
                            {
                                int count = 0;
                                if (items[i + 1] == "true")
                                {

                                    DishWithItem dishofitem = new DishWithItem();
                                    dishofitem.dishId = itemcoun.dishID;
                                    dishofitem.itemId =getitems.itemId;
                                dishofitem.priceOfItems = int.Parse(items[i + 3]);
                                dishofitem.qunatityOfItems = int.Parse(items[i + 4]);
                                dishofitem.requestID = idofrequest;
                                Item getid = new Item();
                                using (MehriamarqueeEntities mh = new MehriamarqueeEntities())
                                {
                                    getid = mh.Items.Where(X => X.itemId == getitems.itemId).FirstOrDefault();
                                    if (getid.quantity >= int.Parse(items[i + 4]))
                                    {

                                        getid.quantity = getid.quantity - int.Parse(items[i + 4]);
                                        mh.Entry(getid).State = System.Data.Entity.EntityState.Modified;
                                        mh.SaveChanges();
                                    }
                                    else
                                    {
                                        TempData["message"] = "Quantity is low  for required quantity";
                                        goto exit
                                        ;
                                    }
                                }
                                meh.DishWithItems.Add(dishofitem);
                                meh.SaveChanges();
                                    i = i + 4;
                                    count++;
                                }

                                if (count == 0)
                                {
                                    i = i + 3;

                                }
                               
                               
                                
                            
                          


                        }
                    }
            }
            }

            for (int i = 0; i < Beve.Count; i++)
            {

                foreach (var itemcoun in dihes)
                {
                    if (Beve[i] == itemcoun.dishName)
                    {

                        foreach (var getitems in Beveitems)
                        {
                            int count = 0;
                            if (Beve[i + 1] == "true")
                            {

                                beveragesWithFunctionWithMenu dishofitem = new beveragesWithFunctionWithMenu();
                                dishofitem.dishID= itemcoun.dishID;
                                dishofitem.beverageID = getitems.beverageId;
                                dishofitem.PriceBeverages = int.Parse(Beve[i + 3]);
                                dishofitem.quantityBeverages = int.Parse(Beve[i + 4]);
                                dishofitem.requestID = idofrequest;
                                Beverage getid = new Beverage();
                                using (MehriamarqueeEntities mh = new MehriamarqueeEntities())
                                {
                                    getid = mh.Beverages.Where(X => X.beverageId == getitems.beverageId).FirstOrDefault();
                                    if (getid.quantityOfBeverages >= int.Parse(Beve[i + 4]))
                                    {

                                        getid.quantityOfBeverages = getid.quantityOfBeverages - int.Parse(Beve[i + 4]);
                                        mh.Entry(getid).State = System.Data.Entity.EntityState.Modified;
                                        mh.SaveChanges();
                                    }
                                    else
                                    {
                                        TempData["message"] = "Quantity is low  for required quantity";
                                        goto exit
                                        ;
                                    }
                                }
                                meh.beveragesWithFunctionWithMenus.Add(dishofitem);
                                meh.SaveChanges();
                                i = i + 4;
                                count++;
                            }

                            if (count == 0)
                            {
                                i = i + 3;

                            }







                        }
                    }
                }
            }
            for (int i = 0; i < Desert.Count; i++)
            {

                foreach (var itemcoun in dihes)
                {
                    if (Desert[i] == itemcoun.dishName)
                    {

                        foreach (var getitems in Desetitems)
                        {
                            int count = 0;
                            if (Desert[i + 1] == "true")
                            {

                                DesertWithFunctionWithMenu dishofitem = new DesertWithFunctionWithMenu();
                                dishofitem.dishID = itemcoun.dishID;
                                dishofitem.desertID = getitems.desertId;
                                dishofitem.PriceDesert= int.Parse(Desert[i + 3]);
                                dishofitem.quantityDesert = int.Parse(Desert[i + 4]);
                                dishofitem.requestID = idofrequest;
                                Desert getid = new Desert();
                                using (MehriamarqueeEntities mh = new MehriamarqueeEntities())
                                {
                                    getid = mh.Deserts.Where(X => X.desertId == getitems.desertId).FirstOrDefault();
                                    if (getid.quantityOfdesert >= int.Parse(Desert[i + 4]))
                                    {

                                        getid.quantityOfdesert = getid.quantityOfdesert- int.Parse(Desert[i + 4]);
                                        mh.Entry(getid).State = System.Data.Entity.EntityState.Modified;
                                        mh.SaveChanges();
                                    }
                                    else
                                    {
                                        TempData["message"] = "Quantity is low  for required quantity";
                                        goto exit
                                        ;
                                    }
                                }
                                meh.DesertWithFunctionWithMenus.Add(dishofitem);
                                meh.SaveChanges();
                                i = i + 4;
                                count++;
                            }

                            if (count == 0)
                            {
                                i = i + 3;

                            }







                        }
                    }
                }
            }
            exit:

            FunctionRequestedTable func = meh.FunctionRequestedTables.Where(X => X.requestID == idofrequest).FirstOrDefault();
            func.Status = "SERVED";
            meh.Entry(func).State = System.Data.Entity.EntityState.Modified;
            meh.SaveChanges();
            return View("Index");
        }
    }
}