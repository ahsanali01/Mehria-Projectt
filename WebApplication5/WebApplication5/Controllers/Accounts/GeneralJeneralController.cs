using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.DB;
using WebApplication5.ViewModel.CustomerView;

namespace WebApplication5.Controllers.Accounts
{
    public class GeneralJeneralController : Controller
    {
     
        // GET: GeneralJeneral
        [Authorize(Roles = "Accountant")]
        public ActionResult general()
        {
            MehriamarqueeEntities meh = new MehriamarqueeEntities();
           List<Account> account = meh.Accounts.ToList();
            return View(account);
        }

        public ActionResult Addingnewaccounts()
        {
           
            return View();
        }
        public ActionResult AddingnewaccountsPost(AddnewAccounts account)
        {
            MehriamarqueeEntities mqe = new MehriamarqueeEntities();
            Account acc = new Account();
            acc.accountName = account.accountName;
            acc.Address = account.Address;
            acc.Description = account.Description;
            acc.mobileNo = account.mobileNo;
            mqe.Accounts.Add(acc);
            mqe.SaveChanges();
            TempData["message"] = "Account Added Successfully";
            return RedirectToAction("Addingnewaccounts");
        }
        public ActionResult addgeneraljenrnal(int selectedaccountid)
        {
          
            MehriamarqueeEntities mqe = new MehriamarqueeEntities();
            List<headOfAccount> hed = mqe.headOfAccounts.ToList();
             
        ViewBag.selectedaccountid = selectedaccountid;

            ViewBag.hed = hed;
            List<subTypesOfHeadAccount> subhed = mqe.subTypesOfHeadAccounts.ToList();
            ViewBag.subhed = subhed;
            
            return View();
        }
        public ActionResult addgeneraljenrnalPost(AddGeneralJournalClass general)
        {
            MehriamarqueeEntities mqe = new MehriamarqueeEntities();
            AccountTransaction acctr = new AccountTransaction();
            acctr.accountNo = general.accountNo;
            acctr.transactionDate = general.transactionDate;
            acctr.transactionName = general.transactionName;
            acctr.Debit_Credit = general.Debit_Credit;
            acctr.amount = general.amount;
            acctr.subtypeID = general.subtype;

            mqe.AccountTransactions.Add(acctr);
            mqe.SaveChanges();

            SubAccountBalance sub = new SubAccountBalance();
            sub.subID = general.subtype;
            sub.accountNo = general.accountNo;
            sub.Date = general.transactionDate;
            if (general.Debit_Credit == "Debit")
            {
                sub.Debit = general.amount;
                sub.Credit = 0;
            }
            else
            {
                sub.Debit = 0;
                sub.Credit = general.amount;
            }
            mqe.SubAccountBalances.Add(sub);
            mqe.SaveChanges();

            TempData["message"] = "General journal Added Successfully";
            return RedirectToAction("general");
        }
        }
}