using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class registerdocDto
    {
        public List<Doctor> Doctors { get; set; }                        //2-3 yerde bu classdan isdifade edilib
        public List<DoctorCategory> doctorCategories { get; set; }

        public List<Beyanat> Beyanats { get; set; }
    }
}