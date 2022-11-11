using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class DocProfileDto
    {
        public Doctor doctor { get; set; }
        public List<Comment> comments { get; set; }
    }
}