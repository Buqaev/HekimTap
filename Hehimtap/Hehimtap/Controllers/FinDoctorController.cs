using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    [AllowAnonymous]
    public class FinDoctorController : Controller
    {
        // GET: FinDoctor
        HekimTapEntities db = new HekimTapEntities();


        public ActionResult Index()
        {


            return View();
        }




                                         //Contacts hisse


        [HttpGet]
        public ActionResult GetContact()
        {
            List<Admin> admins = db.Admins.ToList();
            return View(admins);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            contact.Status = true;
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("ClikPage");
        }

        public ActionResult ClikPage()
        {
            List<Admin> admins = db.Admins.ToList();

            return View(admins);
        }
    }
}