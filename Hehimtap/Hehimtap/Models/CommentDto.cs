using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hehimtap.Models
{
    public class CommentDto
    {
        public User User { get; set; }
        public Doctor Doctor { get; set; }

        public Comment Comment { get; set; }

    }
}