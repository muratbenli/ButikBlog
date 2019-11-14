using ButikBlog.Areas.Admin.ViewModels;
using ButikBlog.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ButikBlog.Areas.Admin.Controllers
{
    [Breadcrumb("Anasayfa")]
    public class DashboardController : AdminBaseController
    {

        // GET: Admin/Dashboard
        [Breadcrumb("İndeks")]
        public ActionResult Index()
        {
            var model = new DashboardIndexViewModel
            {
                CategoryCount = db.Categories.Count(),
                PostCount = db.Posts.Count(),
                UserCount = db.Users.Count(),
                CommentCount = db.Comments.Count()
            };

            return View(model);
        }
    }
}