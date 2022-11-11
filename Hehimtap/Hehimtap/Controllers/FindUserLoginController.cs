using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    [AllowAnonymous]
    public class FindUserLoginController : Controller
    {
        // GET: FindUserLogin
        HekimTapEntities db = new HekimTapEntities();

       
        public ActionResult Index()
        {
            return View();
        }
     
        
        public ActionResult Create(User user)
        {
            user.Status = true;
            user.BankKartAd = "Bosdur(Daxil edilmeyib)";
            user.BankKartNo = "Bosdur(Daxil edilmeyib)";
            user.KartMuhavizeKod = "Bosdur(Daxil edilmeyib)";
            db.Users.Add(user);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}