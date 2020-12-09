using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;
using Rotativa;

namespace WebApplication5.Controllers.Stocks
{
    [Authorize(Roles = "Stockkeeper,Accountant")]
    public class StockGeneratedreportController : Controller
    {
        // GET: StockGeneratedreport
        public ActionResult StockReports()
        {
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {

                List<FunctionRequestedTable> request = meh.FunctionRequestedTables.Where(X=>X.Status=="SERVED").ToList();
               

                List<CheckFunctionRequestViewModel> Request = request.Select(X => new CheckFunctionRequestViewModel
                {
                    requestID = X.requestID,
                    functionID = X.functionID,
                    requestDate = X.requestDate,
                    bookingDate = X.Bookingdata.bookingDate,
                   noofGuests = X.Bookingdata.noofGuest,
                    rateperGuest = X.Bookingdata.rateperGuest,
                    functionDate = X.Bookingdata.functionDate,
                    menuID = X.Bookingdata.MenuId,
                    menuName = X.Bookingdata.Menu.menuName
                }).ToList();

                return View(Request);
            }
        }


       
        public ActionResult StockReportsPost (int getIDrequest)
        {

            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {

                List<FunctionRequestedTable> funcrequest = meh.FunctionRequestedTables.ToList();
               

                List<StockReportClass> funcRequest = funcrequest.Select(X => new StockReportClass
                {
                    requestID = X.requestID,
                    functionID = X.Bookingdata.functionID,
                    requestDate = X.requestDate,
                    bookingDate = X.Bookingdata.bookingDate,
                    functionDate = X.Bookingdata.functionDate,
                    noofGuest = X.Bookingdata.noofGuest,
                    rateperGuest = X.Bookingdata.rateperGuest,
                    AdvancePayment = X.Bookingdata.AdvancePayment,
                    RemainingPayment = X.Bookingdata.RemainingPayment,
                    Extras = X.Bookingdata.Extras,
                    TotalCharges = X.Bookingdata.TotalCharges,
                    timeShift = X.Bookingdata.timeShift,
                    menuName = X.Bookingdata.Menu.menuName,
                    programName = X.Bookingdata.Program.programName,
                }).ToList();

                ViewBag.getIDrequest = getIDrequest;
                List<DishWithItem> request = meh.DishWithItems.ToList();
            

                List<StockItemReportClass> Request = request.Select(X => new StockItemReportClass
                {
                    requestID = X.requestID,

                    itemName = X.Item.itemName,
                    priceOfItems = X.priceOfItems,
                    qunatityOfItems = X.qunatityOfItems,
                    dishName= X.Dish.dishName


                }).ToList();
                ViewData["Request"] = Request;

                List<DesertWithFunctionWithMenu> Desertrequest = meh.DesertWithFunctionWithMenus.ToList();
                List<StockDesertReportClass> DesertRequestlist = new List<StockDesertReportClass>();

                List<StockDesertReportClass> DesertRequest = Desertrequest.Select(X => new StockDesertReportClass
                {
                    requestID = X.requestID,

                    desertName = X.Desert.desertName,
                    PriceDesert = X.PriceDesert,
                    quantityDesert = X.quantityDesert,
                    dishName = X.Dish.dishName


                }).ToList();
                ViewData["DesertRequest"] = DesertRequest;
                List<beveragesWithFunctionWithMenu> Beveragerequest = meh.beveragesWithFunctionWithMenus.ToList();
              

                List<StockBeveragesClass> BeverageRequest = Beveragerequest.Select(X => new StockBeveragesClass
                {
                    requestID = X.requestID,
                    beveragesName = X.Beverage.beveragesName,
                    PriceBeverages = X.PriceBeverages,
                    quantityBeverages = X.quantityBeverages,
                    dishName = X.Dish.dishName



                }).ToList();
                ViewData["BeverageRequest"] = BeverageRequest;


                return View(funcRequest);
            }
        }
        public ActionResult StockInOut()
        {
            using(MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {

                List<int> quantitytotalofItem = new List<int>();
                List<int> quantitytotalofBeve= new List<int>();
                List<int> quantitytotalofDesert = new List<int>();
                List<int> quantityintotalofItem = new List<int>();
                List<int> quantityintotalofBeve = new List<int>();
                List<int> quantityintotalofDesert = new List<int>();
                List<DishWithItem> im = meh.DishWithItems.ToList();
                List<Item> itm = meh.Items.ToList();
                List<beveragesWithFunctionWithMenu> beveim = meh.beveragesWithFunctionWithMenus.ToList();
                List<Beverage> Beveitm = meh.Beverages.ToList();
                List<DesertWithFunctionWithMenu> desertim = meh.DesertWithFunctionWithMenus.ToList();
                List<Desert> desertitm = meh.Deserts.ToList();
                List<QuantityupdateBeveragestable> quabeve = meh.QuantityupdateBeveragestables.ToList();
                List<QuantityupdatedDeserttable> quadese = meh.QuantityupdatedDeserttables.ToList();
                List<QuantityupdatedItemtable> quaitem = meh.QuantityupdatedItemtables.ToList();
                ViewData["Beveitm"] = Beveitm;
                ViewData["desertitm"] = desertitm;

                int stock=0;
                int stockofBeverages = 0;
                int stockofDeserts = 0;
                int stockin = 0;
                int stockinofBeverages = 0;
                int stockinofDeserts = 0;
                int j = 0;
                int jin = 0;
                while (jin < quaitem.Count)
                {



                    foreach (var item in itm)
                    {
                        foreach (var i in quaitem)
                        {
                            if (item.itemId == i.itemID)
                            {
                                stockin = stockin + i.Quantity;
                            }
                        }
                        quantityintotalofItem.Add(stockin);
                        jin++;
                        stockin = 0;
                    }

                }
                ViewBag.quantityintotalofItem = quantityintotalofItem;
                while (j < itm.Count)
                {

                
                
                    foreach (var item in itm)
                    {
                        foreach (var i in im)
                        {
                            if (  item.itemId == i.itemId)
                            {
                                stock = stock+i.qunatityOfItems;
                            }
                        }
                        quantitytotalofItem.Add(stock);
                        j++;
                        stock = 0;
                    }
                    
                }

                ViewBag.quantitytotalofItem = quantitytotalofItem;


                int kin = 0;
                while (kin < quabeve.Count)
                {



                    foreach (var item in Beveitm)
                    {
                        foreach (var i in quabeve)
                        {
                            if (item.beverageId == i.beverageID)
                            {
                                stockinofBeverages = stockinofBeverages + i.Quantity;
                            }
                        }
                        quantityintotalofBeve.Add(stockinofBeverages);
                        kin++;
                        stockinofBeverages = 0;
                    }

                }

                ViewBag.quantityintotalofBeve = quantityintotalofBeve;
                int k = 0;
                while (k < Beveitm.Count)
                {



                    foreach (var item in Beveitm)
                    {
                        foreach (var i in beveim)
                        {
                            if (item.beverageId == i.beverageID)
                            {
                                stockofBeverages = stockofBeverages + i.quantityBeverages;
                            }
                        }
                        quantitytotalofBeve.Add(stockofBeverages);
                        k++;
                        stockofBeverages = 0;
                    }

                }

                ViewBag.quantitytotalofBeve = quantitytotalofBeve;

                int l = 0;
                while (l < desertitm.Count)
                {



                    foreach (var item in desertitm)
                    {
                        foreach (var i in desertim)
                        {
                            if (item.desertId == i.desertID)
                            {
                                stockofDeserts = stockofDeserts + i.quantityDesert;
                            }
                        }
                        quantitytotalofDesert.Add(stockofDeserts);
                        l++;
                        stockofDeserts = 0;
                    }

                }

                ViewBag.quantitytotalofDesert = quantitytotalofDesert;

                int lin = 0;
                while (lin < quadese.Count)
                {



                    foreach (var item in desertitm)
                    {
                        foreach (var i in quadese)
                        {
                            if (item.desertId == i.desertID)
                            {
                                stockinofDeserts = stockinofDeserts + i.Quantity;
                            }
                        }
                        quantityintotalofDesert.Add(stockinofDeserts);
                        lin++;
                        stockinofDeserts=0;
                    }

                }

                ViewBag.quantityintotalofDesert = quantityintotalofDesert;
                return View(itm);
            }

            
              
        }
        public ActionResult History()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
            List<QuantityupdatedItemtable> quaitem = meh.QuantityupdatedItemtables.ToList();
            List<QuantityupdateBeveragestable> quaBeve = meh.QuantityupdateBeveragestables.ToList();
            List<QuantityupdatedDeserttable> quaDese = meh.QuantityupdatedDeserttables.ToList();
            ViewData["quaBeve"] = quaBeve;
            ViewData["quaDese"] = quaDese;
            return View(quaitem);
        }
    }
}
