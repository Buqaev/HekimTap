using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class CloudDto
    {
        public List<News> News { get; set; }
        public List<Teq> Teqs { get; set; }
        public List<Cloud> Clouds { get; set; }
    }
}