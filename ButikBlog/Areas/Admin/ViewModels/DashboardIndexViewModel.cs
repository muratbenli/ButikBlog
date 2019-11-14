using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ButikBlog.Areas.Admin.ViewModels
{
    public class DashboardIndexViewModel
    {
        public int CategoryCount { get; set; }

        public int PostCount { get; set; }

        public int UserCount { get; set; }

        public int CommentCount { get; set; }
    }
}