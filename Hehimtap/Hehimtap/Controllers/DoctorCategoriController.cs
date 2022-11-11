using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers
{
    public class DoctorCategoriController : Controller
    {
        // GET: DoctorCategori

        HekimTapEntities db = new HekimTapEntities();

        
        [HttpGet]
        public ActionResult Index()
        {
            List<DoctorCategory> doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();

            return View(doctorCategories);
        }

        
        public ActionResult Create(DoctorCategory doctorCategory, HttpPostedFileBase Sekil)
        {
            doctorCategory.Status = true;
            db.DoctorCategories.Add(doctorCategory);

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                doctorCategory.Ikon = Path.GetFileName(Sekil.FileName);

            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            DoctorCategory doctorCategory = db.DoctorCategories.FirstOrDefault(x => x.Id == Id);
            doctorCategory.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdaetGosder(int Id)
        {
            DoctorCategory doctorCategory = db.DoctorCategories.FirstOrDefault(x => x.Id == Id);

            return View(doctorCategory);

        }
        public ActionResult Update(DoctorCategory doctorCategory, HttpPostedFileBase Sekil)
        {
            DoctorCategory d = db.DoctorCategories.FirstOrDefault(f => f.Id == doctorCategory.Id);
            d.Ad = doctorCategory.Ad;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                d.Ikon = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

           


            return RedirectToAction("Index");
        }
    }
}