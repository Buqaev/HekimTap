using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        HekimTapEntities db = new HekimTapEntities();

        [HttpGet]
        public ActionResult Index(int? PersonelCategoriId)
        {
            PersonelDto model = new PersonelDto();
            if (PersonelCategoriId == null)
            {
                model.Personels = db.Personels.Where(w => w.Status == true).ToList();
            }
            else
            {
                model.Personels = db.Personels.Where(w => w.Status == true && w.PersonelId == PersonelCategoriId).ToList();

            }
            model.PersonelCategories = db.PersonelCategories.Where(w => w.Status == true).ToList();

            return View(model);
        }

        
        public ActionResult PersonelCreate()
        {
            List<PersonelCategory> personelCategories = db.PersonelCategories.Where(x => x.Status == true).ToList();

            return View(personelCategories);
        }

        
        public ActionResult Create(Personel p, HttpPostedFileBase Sekil)
        {

            
            p.Status = true;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                p.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Personel personel = db.Personels.FirstOrDefault(x => x.Id == Id);
            personel.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PersonelUpdate(int Id)
        {
            Personel personel = db.Personels.FirstOrDefault(x => x.Id == Id);
            ViewBag.per = db.Personels.Where(w => w.Status == true).ToList();
            return View(personel);
        }

        public ActionResult Update(Personel p, HttpPostedFileBase Sekil)
        {
            Personel personel = db.Personels.FirstOrDefault(f => f.Id == p.Id);
            personel.Ad = p.Ad;
            personel.Soyad = p.Soyad;
            //personel.PersonelId = p.PersonelId;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                personel.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

            // nw.Like = news.Like +1;


            return RedirectToAction("Index");
        }
    }
}