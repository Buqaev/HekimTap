using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        HekimTapEntities db = new HekimTapEntities();
        public ActionResult Index()
        {
            List<Doctor> doctors = db.Doctors.Where(x => x.Status == true).ToList();

            return View(doctors);
        }

        public ActionResult Delete(int Id)
        {
            Doctor doctor = db.Doctors.FirstOrDefault(x => x.Id == Id);
            doctor.Status = false;
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}