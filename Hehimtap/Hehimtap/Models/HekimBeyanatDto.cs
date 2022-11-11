using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class HekimBeyanatDto
    {
        public List<Doctor> Doctors { get; set; }
        public List<Beyanat> Beyanats { get; set; }

    }
}