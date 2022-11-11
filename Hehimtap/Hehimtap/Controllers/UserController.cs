using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        HekimTapEntities db = new HekimTapEntities();

        public ActionResult Index()
        {
            List<User> users = db.Users.Where(x => x.Status == true).ToList();


            return View(users);
        }

        public ActionResult Delete(int Id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == Id);
            user.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Block()
        {
            List<User> users = db.Users.Where(x => x.Status == false).ToList();


            return View(users);
        }

        public ActionResult NoBlock(int Id)
        {
            User users = db.Users.FirstOrDefault(x => x.Id == Id);
            users.Status = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}