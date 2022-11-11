using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
  
        public class NewsDto
        {
            public List<News> News { get; set; }
            public List<NewsCategory> NewsCategories { get; set; }
        }
    
}