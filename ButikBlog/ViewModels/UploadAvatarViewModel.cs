using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ButikBlog.ViewModels
{
    public class UploadAvatarViewModel
    {
        public string Photo { get; set; }

        [Required(ErrorMessage ="Resim dosyası seçmediniz.")]
        public HttpPostedFileBase File { get; set; }
    }
}