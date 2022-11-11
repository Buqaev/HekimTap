using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers
{
    public class PersonelCategoriController : Controller
    {
        // GET: PersonelCategori

        HekimTapEntities db = new HekimTapEntities();


        [HttpGet]
        public ActionResult Index()
        {
            List<PersonelCategory> personelCategories = db.PersonelCategories.Where(x => x.Status == true).ToList();

            return View(personelCategories);
        }
        [HttpPost]
        public ActionResult Create(PersonelCategory p)
        {
            p.Status = true;
            db.PersonelCategories.Add(p);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult UpdateCategoriy(int Id)
        {
            PersonelCategory personelCategory = db.PersonelCategories.FirstOrDefault(x => x.Id == Id);

            return View(personelCategory);
        }

        public ActionResult Update(PersonelCategory p)
        {
            PersonelCategory personelCategory = db.PersonelCategories.FirstOrDefault(x => x.Id == p.Id);

            personelCategory.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            PersonelCategory personelCategory = db.PersonelCategories.FirstOrDefault(x => x.Id == Id);
            personelCategory.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}