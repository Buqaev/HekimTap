using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class DoctorDto
    {
        public Doctor doctor { get; set; }
        public List<Comment> comments { get; set; }
        public List<Beyanat> Beyanats { get; set; }
        public List<Ziyaret> Ziyarets { get; set; }
        public User user { get; set; }
    }
}