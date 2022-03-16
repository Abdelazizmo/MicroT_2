using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microtech_WebApiTask_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        //private readonly MicrotechTaskContext db;

        //public AccountController(MicrotechTaskContext _db)
        //{
        //    db = _db;
        //}

        MicrotechTaskContext db = new MicrotechTaskContext();

        //[HttpGet]
        //public IEnumerable<Account> Get()
        //{
        //    using (var context = new MicrotechTaskContext())
        //    {
        //        // to gt all accounts
        //        return context.Accounts.ToList();

        //        //to return only 1 account 
        //        //return context.Accounts.Where(acc => acc.AccNumber == "01").ToList();
        //    }

        //}

        //[HttpGet]
        //public List<Account> GetByAccNumver()
        //{
        //    //List<Accounting> Items = await _context.Accounting.Where(q => q.Accounting.Where(r => r.ParentAccountId == q.AccountId).count()==0).ToListAsync();
        //    List<Account> Items = db.Accounts.Where(q => q.InverseAccParentNavigation.Where(r => r.AccParent == q.AccNumber).Count() == 0).ToList();

        //    return Items;
        //}


        [HttpGet]
        public List<Account> GetByAccNumver()
        {
            //List<Accounting> Items = await _context.Accounting.Where(q => q.Accounting.Where(r => r.ParentAccountId == q.AccountId).count()==0).ToListAsync();
            //*List<Account> Items = db.Accounts.Where(q => q.InverseAccParentNavigation.Where(r => r.AccParent == q.AccNumber).Count() == 0).ToList()*/

           
           
            List<Account> AllAccounts = db.Accounts.ToList();
            List<Account> MainAccounts = AllAccounts.Where(a => a.AccParent == null).ToList();

            return AllAccounts;
        }



    }
    }
