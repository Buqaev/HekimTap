using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    [AllowAnonymous]
    public class FinHomePageController : Controller
    {
        // GET: FinHomePage
        HekimTapEntities db = new HekimTapEntities();

        public ActionResult Index(int? DoctorCategoriesId)
        {
            registerdocDto model = new registerdocDto();
            if (DoctorCategoriesId == null)
            {
                model.Doctors = db.Doctors.Where(w => w.Status == true).ToList();
            }
            else
            {
                model.Doctors = db.Doctors.Where(w => w.Status == true && w.DoctorCategoriesId == DoctorCategoriesId).ToList();

            }

            //model.Doctors = db.Doctors.Where(w => w.Status == true).ToList();
            model.doctorCategories = db.DoctorCategories.Where(w => w.Status == true).ToList();
            model.Beyanats = db.Beyanats.Where(x => x.Status == true).OrderByDescending(x=>x.Doctor.Baxissayi).Take(3).ToList();
            
            return View(model);

           
        }
        public ActionResult DoctorCateList(int Id)
        {



            var deyer = db.Beyanats.Where(x => x.Doctor.DoctorCategoriesId == Id).ToList();

            return View(deyer);


        }


    }
}