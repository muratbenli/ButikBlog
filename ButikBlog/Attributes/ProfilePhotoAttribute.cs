using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ButikBlog.Attributes
{
    public class ProfilePhotoAttribute : ValidationAttribute
    {
        /// <summary>
        /// Maximum file size in bytes
        /// </summary>
        public int MaxFileSize { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            HttpPostedFileBase file = (HttpPostedFileBase)value;

            if (file.ContentLength > MaxFileSize)
            {
                return false;
            }

            if (!file.ContentType.StartsWith("image/"))
            {
                return false;
            }

            return true;
        }
    }
}