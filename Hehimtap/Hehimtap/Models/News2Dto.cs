using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class News2Dto
    {
        public List<News> news { get; set; }
        public List<News> news2 { get; set; }
        public List<NewsCategory> newsCategories { get; set; }
        public List<DoctorCategory> doctorCategories { get; set; }

        public List<Cloud> Clouds { get; set; }
        public List<Teq> Teqs { get; set; }
        public List<Review> reviews { get; set; }
       
    }
}