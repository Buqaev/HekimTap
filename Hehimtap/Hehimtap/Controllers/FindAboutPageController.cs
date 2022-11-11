using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers
{
    [AllowAnonymous]
    public class FindAboutPageController : Controller
    {
        // GET: FindAboutPage
        HekimTapEntities db = new HekimTapEntities();

        public ActionResult Index()
        {
            AboutDto model = new AboutDto();

            model.Abouts = db.Abouts.ToList();
            model.Personels = db.Personels.Where(x => x.Status == true).ToList();
            model.contacts = db.Contacts.Where(x => x.Status == true).ToList();
            var p = db.Personels.Where(x=>x.Status==true).Count();
            ViewBag.personelSay = p;
            ViewBag.personelSay = db.Personels.Where(x => x.Status == true).Count();
            ViewBag.userSay = db.Users.Where(x => x.Status == true).Count();
            return View(model);
        }
    }
}