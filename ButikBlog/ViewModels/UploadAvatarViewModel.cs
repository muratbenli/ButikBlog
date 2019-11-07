using ButikBlog.Attributes;
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
        [ProfilePhoto(MaxFileSize = 1000000,ErrorMessage ="1 Mb'den küçük bir resim giriniz.")]
        public HttpPostedFileBase File { get; set; }
    }
}