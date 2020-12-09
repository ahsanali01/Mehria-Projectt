using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;

namespace WebApplication5.Controllers.Accounts
{
    public class GeneralLedgerController : Controller
    {
        // GET: GeneralLedger
        [Authorize(Roles = "Accountant")]
        public ActionResult Creategeneralledger()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
           
            List<AccountTransaction> acctr = meh.AccountTransactions.ToList();
          
            return View(acctr);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Creategeneralledger(int accountname=0,DateTime? FromDate=null,DateTime? ToDate=null)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();

            List<AccountTransaction> acctr = meh.AccountTransactions.Where(X =>X.Account.accountNo==accountname && X.transactionDate>=FromDate && X.transactionDate<=ToDate).ToList();
            List<SubAccountBalance> subacctr  = meh.SubAccountBalances.Where(X => X.Account.accountNo == accountname && X.Date >= FromDate && X.Date <= ToDate).ToList();
            if (accountname != 0 && FromDate != null && ToDate != null && ToDate >= FromDate)
            {
                long creditbalance = 0;
                long debitblance = 0;
                long totalbalance = 0;
                foreach (var i in subacctr)
                {

                    if (i.Credit != 0)
                    {
                        creditbalance = creditbalance + i.Credit;
                    }
                    else
                    {
                        debitblance = debitblance + i.Debit;
                    }
                }

                if (creditbalance >= debitblance)
                {
                    totalbalance = creditbalance - debitblance;
                }
                else
                {
                    totalbalance = debitblance - creditbalance;
                }

                ViewBag.totalbalance = totalbalance;
                ViewBag.Count = subacctr.Count;
            }
            else
            {

                TempData["message"] = " From and To Date can,t be Empty OR To Date must be greater than or equal To From Date";
            }
            return View(acctr);
        }

        public ActionResult TrailBalance()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();

            List<Account> acctr = meh.Accounts.ToList();

            return View(acctr);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult TrailBalance(DateTime? FromDate=null, DateTime? ToDate=null)
        {
            
                MehriamarqueeEntities meh = new MehriamarqueeEntities();

                List<Account> acctr = meh.Accounts.ToList();
            if (FromDate != null && ToDate != null && ToDate >= FromDate)
            {
                List<SubAccountBalance> subacctr = meh.SubAccountBalances.Where(X => X.Date >= FromDate && X.Date <= ToDate).ToList();
                long creditbalance = 0;
                long debitblance = 0;
                long totalsumCreditbalance = 0;
                long totalsumdebitbalance = 0;
                List<long> totalbalancefordebit = new List<long>();
                List<long> totalbalanceforcredit = new List<long>();
                int count = acctr.Count;
                long total = 0;
                foreach (var acc in acctr)
                {

                    foreach (var i in subacctr)
                    {

                        if (acc.accountNo == i.accountNo)
                        {
                            if (i.Credit != 0)
                            {

                                creditbalance = creditbalance + i.Credit;
                            }
                            else
                            {
                                debitblance = debitblance + i.Debit;
                            }
                        }
                    }

                    if (creditbalance >= debitblance)
                    {
                        total = creditbalance - debitblance;
                        totalbalancefordebit.Add(0);
                        totalbalanceforcredit.Add(total);
                    }
                    else
                    {

                        total = debitblance - creditbalance;


                        totalbalancefordebit.Add(total);
                        totalbalanceforcredit.Add(0);
                    }
                    creditbalance = 0;
                    debitblance = 0;
                }

                for (int i = 0; i < totalbalanceforcredit.Count; i++)
                {
                    totalsumCreditbalance = totalsumCreditbalance + totalbalanceforcredit[i];
                }
                for (int i = 0; i < totalbalancefordebit.Count; i++)
                {
                    totalsumdebitbalance = totalsumdebitbalance + totalbalancefordebit[i];
                }
                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;
                ViewBag.totalbalancefordebit = totalbalancefordebit;
                ViewBag.totalbalanceforcredit = totalbalanceforcredit;
                ViewBag.totalsumCreditbalance = totalsumCreditbalance;
                ViewBag.totalsumdebitbalance = totalsumdebitbalance;


            }
            else
            {

                TempData["message"] = " From and To Date cannot be NULL OR To Date must be greater than or equal To From Date";
            }
            return View(acctr);
            
        }

        public ActionResult IncomeStatement()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IncomeStatement(DateTime? FromDate=null, DateTime? ToDate=null)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();



            List<SubAccountBalance> Expense = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 8 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            List<SubAccountBalance> Revenue = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 6 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            if (FromDate != null && ToDate != null && ToDate >= FromDate)
            {
                long totalrevenue = 0;
                long totalexpense = 0;
                long IncomeStatement = 0;




                foreach (var i in Expense)
                {


                    if (i.Debit != 0)
                    {

                        totalexpense = totalexpense + i.Debit;
                    }


                }

                foreach (var i in Revenue)
                {


                    if (i.Credit != 0)
                    {

                        totalrevenue = totalrevenue + i.Credit;
                    }


                }



                IncomeStatement = totalrevenue - totalexpense;








                ViewBag.IncomeStatement = IncomeStatement;
                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;
            }
            else
            {

                TempData["message"] = " From and To Date cannot be NULL OR To Date must be greater than or equal To From Date";
            }

            return View();
        
        }
        public ActionResult Statementofownerequity()
        {

            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Statementofownerequity(DateTime? FromDate=null, DateTime? ToDate=null) {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();



            List<SubAccountBalance> Expense = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 8 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            List<SubAccountBalance> Revenue = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 6 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            if (FromDate != null && ToDate != null && ToDate >= FromDate)
            {
                long totalrevenue = 0;
                long totalexpense = 0;
                long IncomeStatement = 0;
                long totalcapital = 0;
                long totaldrawing = 0;
                long StatementofOwnerEquity = 0;



                foreach (var i in Expense)
                {


                    if (i.Debit != 0)
                    {

                        totalexpense = totalexpense + i.Debit;
                    }


                }

                foreach (var i in Revenue)
                {


                    if (i.Credit != 0)
                    {

                        totalrevenue = totalrevenue + i.Credit;
                    }


                }



                IncomeStatement = totalrevenue - totalexpense;


                List<SubAccountBalance> capital = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 10 && X.Date >= FromDate && X.Date <= ToDate).ToList();
                List<SubAccountBalance> drawing = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 12 && X.Date >= FromDate && X.Date <= ToDate).ToList();

                foreach (var i in capital)
                {


                    if (i.Credit != 0)
                    {

                        totalcapital = totalcapital + i.Credit;
                    }


                }
                foreach (var i in drawing)
                {


                    if (i.Debit != 0)
                    {

                        totaldrawing = totaldrawing + i.Debit;
                    }


                }

                StatementofOwnerEquity = totalcapital + IncomeStatement - totaldrawing;

                ViewBag.StatementofOwnerEquity = StatementofOwnerEquity;
                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;
            }
            else
            {

                TempData["message"] = " From and To Date cannot be NULL OR To Date must be greater than or equal To From Date";
            }
            return View();
                
                
                }

        public ActionResult BalanceSheet()
        {

            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult BalanceSheet(DateTime? FromDate=null, DateTime? ToDate=null)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();



            List<SubAccountBalance> Expense = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 8 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            List<SubAccountBalance> Revenue = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 6 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            if (FromDate != null && ToDate != null && ToDate >= FromDate)
            {
                long totalrevenue = 0;
                long totalexpense = 0;
                long IncomeStatement = 0;
                long totalcapital = 0;
                long totaldrawing = 0;
                long StatementofOwnerEquity = 0;
                long creditbalance = 0;
                long debitblance = 0;
                long totalAssets = 0;
                long totalLiability = 0;

                foreach (var i in Expense)
                {


                    if (i.Debit != 0)
                    {

                        totalexpense = totalexpense + i.Debit;
                    }


                }

                foreach (var i in Revenue)
                {


                    if (i.Credit != 0)
                    {

                        totalrevenue = totalrevenue + i.Credit;
                    }


                }



                IncomeStatement = totalrevenue - totalexpense;


                List<SubAccountBalance> capital = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 10 && X.Date >= FromDate && X.Date <= ToDate).ToList();
                List<SubAccountBalance> drawing = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 12 && X.Date >= FromDate && X.Date <= ToDate).ToList();

                foreach (var i in capital)
                {


                    if (i.Credit != 0)
                    {

                        totalcapital = totalcapital + i.Credit;
                    }


                }
                foreach (var i in drawing)
                {


                    if (i.Debit != 0)
                    {

                        totaldrawing = totaldrawing + i.Debit;
                    }


                }

                StatementofOwnerEquity = totalcapital + IncomeStatement - totaldrawing;

                List<SubAccountBalance> Assets = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 2 && X.Date >= FromDate && X.Date <= ToDate).ToList();
                List<SubAccountBalance> Liability = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 4 && X.Date >= FromDate && X.Date <= ToDate).ToList();

                foreach (var i in Assets)
                {


                    if (i.Credit != 0)
                    {

                        creditbalance = creditbalance + i.Credit;
                    }
                    else
                    {
                        debitblance = debitblance + i.Debit;
                    }

                }
                if (creditbalance >= debitblance)
                {
                    totalAssets = creditbalance - debitblance;
                    creditbalance = 0;
                    debitblance = 0;
                }
                else
                {

                    totalAssets = debitblance - creditbalance;
                    creditbalance = 0;
                    debitblance = 0;


                }

                foreach (var i in Liability)
                {


                    if (i.Credit != 0)
                    {

                        creditbalance = creditbalance + i.Credit;
                    }
                    else
                    {
                        debitblance = debitblance + i.Debit;
                    }

                }
                if (creditbalance >= debitblance)
                {
                    totalLiability = creditbalance - debitblance;

                }
                else
                {

                    totalLiability = debitblance - creditbalance;



                }
                long check = totalLiability + StatementofOwnerEquity;

                ViewBag.check = check;
                ViewBag.totalAssets = totalAssets;
                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;
            }
            else
            {

                TempData["message"] = " From and To Date cannot be NULL OR To Date must be greater than or equal To From Date";
            }
            return View();
        }


        public ActionResult IncomeTax()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IncomeTax(DateTime? FromDate=null, DateTime? ToDate=null)
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();



            List<SubAccountBalance> Expense = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 8 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            List<SubAccountBalance> Revenue = meh.SubAccountBalances.Where(X => X.subTypesOfHeadAccount.typeId == 6 && X.Date >= FromDate && X.Date <= ToDate).ToList();
            if (FromDate != null && ToDate != null && ToDate >= FromDate)
            {
                double totalrevenue = 0;
                double totalexpense = 0;
                double IncomeStatement = 0;




                foreach (var i in Expense)
                {


                    if (i.Debit != 0)
                    {

                        totalexpense = totalexpense + i.Debit;
                    }


                }

                foreach (var i in Revenue)
                {


                    if (i.Credit != 0)
                    {

                        totalrevenue = totalrevenue + i.Credit;
                    }


                }



                IncomeStatement = totalrevenue - totalexpense;
                double incomeTax = 0;

                if (IncomeStatement >= 600000 && IncomeStatement <= 1200000)
                {
                    IncomeStatement = IncomeStatement - 600000;
                    incomeTax = IncomeStatement * 5 / 100;
                }

                else if (IncomeStatement >= 1200000 && IncomeStatement <= 1800000)
                {
                    IncomeStatement = IncomeStatement - 1200000;
                    incomeTax = IncomeStatement * 10 / 100;
                    incomeTax = incomeTax + 30000;
                }
                else if (IncomeStatement >= 1800000 && IncomeStatement <= 2500000)
                {

                    IncomeStatement = IncomeStatement - 1800000;
                    incomeTax = IncomeStatement * 15 / 100;
                    incomeTax = incomeTax + 90000;
                }
                else if (IncomeStatement >= 2500000 && IncomeStatement <= 3500000)
                {

                    IncomeStatement = IncomeStatement - 2500000;
                    incomeTax = IncomeStatement * 17.5 / 100;
                    incomeTax = incomeTax + 90000;
                }

                else if (IncomeStatement >= 3500000 && IncomeStatement <= 5000000)
                {

                    IncomeStatement = IncomeStatement - 3500000;
                    incomeTax = IncomeStatement * 20 / 100;
                    incomeTax = incomeTax + 370000;
                }
                else if (IncomeStatement >= 5000000 && IncomeStatement <= 8000000)
                {

                    IncomeStatement = IncomeStatement - 5000000;
                    incomeTax = IncomeStatement * 22.5 / 100;
                    incomeTax = incomeTax + 670000;
                }
                else if (IncomeStatement >= 8000000 && IncomeStatement <= 12000000)
                {

                    IncomeStatement = IncomeStatement - 8000000;
                    incomeTax = IncomeStatement * 25 / 100;
                    incomeTax = incomeTax + 1345000;
                }

                else if (IncomeStatement >= 12000000 && IncomeStatement <= 30000000)
                {

                    IncomeStatement = IncomeStatement - 12000000;
                    incomeTax = IncomeStatement * 27.5 / 100;
                    incomeTax = incomeTax + 2345000;
                }
                else if (IncomeStatement >= 30000000 && IncomeStatement <= 50000000)
                {

                    IncomeStatement = IncomeStatement - 30000000;
                    incomeTax = IncomeStatement * 30 / 100;
                    incomeTax = incomeTax + 7295000;
                }
                else if (IncomeStatement >= 50000000 && IncomeStatement <= 75000000)
                {

                    IncomeStatement = IncomeStatement - 50000000;
                    incomeTax = IncomeStatement * 32.5 / 100;
                    incomeTax = incomeTax + 13295000;
                }
                else if (IncomeStatement >= 75000000)
                {

                    IncomeStatement = IncomeStatement - 75000000;
                    incomeTax = IncomeStatement * 35 / 100;
                    incomeTax = incomeTax + 21420000;
                }







                ViewBag.incomeTax = incomeTax;
                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;

            }
            else
            {

                TempData["message"] = " From and To Date cannot be NULL OR To Date must be greater than or equal To From Date";
            }
            return View();

        }


    }
}