using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ButikBlog.Attributes
{
    public class BreadcrumbAttribute : Attribute
    {
        public string Name { get; set; }

        public BreadcrumbAttribute(string name)
        {
            Name = name;
        }
    }
}