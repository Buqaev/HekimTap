using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        HekimTapEntities db = new HekimTapEntities();

        public ActionResult Index()
        {
            List<Admin> admins = db.Admins.ToList();


            return View(admins);
        }

        public ActionResult UpdateAdmin(int Id)
        {
            Admin admin = db.Admins.FirstOrDefault(x => x.Id == Id);

            return View(admin);
        }

        public ActionResult Update(Admin a)
        {
            Admin admin = db.Admins.FirstOrDefault(x => x.Id == a.Id);
            admin.Ad = a.Ad;
            admin.Soyad = a.Soyad;
            admin.Mail = a.Mail;
            admin.Sifre = a.Sifre;
            admin.Id = a.Id;
            db.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}