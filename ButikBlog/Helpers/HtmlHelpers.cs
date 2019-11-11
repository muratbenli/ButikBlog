using ButikBlog.Areas.Admin.Controllers;
using ButikBlog.Attributes;
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

            MethodInfo mi = t.GetMethods().FirstOrDefault(x=>x.Name == action);

            BreadcrumbAttribute ba = mi.GetCustomAttribute(typeof(BreadcrumbAttribute)) as BreadcrumbAttribute;

            if (ba == null)
                return action;

            return ba.Name;
        }
    }
}