using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class AboutDto
    {
        public List<About> Abouts { get; set; }
        public List<Personel> Personels { get; set; }
        public List<Contact> contacts { get; set; }
    }
}