using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        HekimTapEntities db = new HekimTapEntities();
        public ActionResult Index()
        {
            List<Contact> contacts = db.Contacts.Where(x => x.Status == true).ToList();

            return View(contacts);
        }

        public ActionResult Delete(int Id)
        {
            Contact contact = db.Contacts.FirstOrDefault(x => x.Id == Id);
            contact.Status = false;
            db.SaveChanges();
            return View();
        }
    }
}