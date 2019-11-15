using ButikBlog.Areas.Admin.Controllers;
using ButikBlog.Attributes;
using ButikBlog.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ButikBlog.Helpers
{
    public static class HtmlHelpers
    {
        public static string ControllerName(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.RouteData.Values["controller"].ToString();
        }

        public static string ActionName(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.RouteData.Values["action"].ToString();
        }

        public static string BreadcrumbControllerName(this HtmlHelper htmlHelper)
        {
            string controller = htmlHelper.ControllerName();

            Type t = Type.GetType("ButikBlog.Areas.Admin.Controllers." + controller + "Controller");
            object[] attributes = t.GetCustomAttributes(typeof(BreadcrumbAttribute), true);

            if (attributes.Length == 0)
            {
                return controller;
            }

            var attr = (BreadcrumbAttribute)attributes[0];

            return attr.Name;
        }
        public static string BreadcrumbActionName(this HtmlHelper htmlHelper)
        {
            string controller = htmlHelper.ControllerName();
            string action = htmlHelper.ActionName();
            Type t = Type.GetType("ButikBlog.Areas.Admin.Controllers." + controller + "Controller");

            MethodInfo mi = t.GetMethods().FirstOrDefault(x => x.Name == action);

            BreadcrumbAttribute ba = mi.GetCustomAttribute(typeof(BreadcrumbAttribute)) as BreadcrumbAttribute;

            if (ba == null)
                return action;

            return ba.Name;
        }

        public static IHtmlString ShowPostIntro(this HtmlHelper htmlHelper, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return htmlHelper.Raw("");
            }

            int pos = content.IndexOf("<hr>");

            if (pos == -1)
            {
                return htmlHelper.Raw(content);
            }

            return htmlHelper.Raw(content.Substring(0, pos));
        }

        public static IHtmlString ShowPost(this HtmlHelper htmlHelper, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return htmlHelper.Raw("");
            }

            int pos = content.IndexOf("<hr>");

            if (pos == -1)
            {
                return htmlHelper.Raw(content);
            }

            return htmlHelper.Raw(content.Remove(pos, 4));
        }

        public static string ProfilePhotoPath(this HtmlHelper htmlHelper)
        {
            string userId = htmlHelper.ViewContext.HttpContext.User.Identity.GetUserId();

            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);

            //giris yapan kullanici varsa 
            if (userId != null)
            {
                using (var db = new ApplicationDbContext())
                {
                    var user = db.Users.Find(userId);

                    // fotosu varsa
                    if (user != null && !string.IsNullOrEmpty(user.Photo))
                    {
                        return urlHelper.Content("~/Upload/Profiles/" + user.Photo);
                    }
                }
            }

            return urlHelper.Content("~/Images/avatar.jpg");
        }
    }
}