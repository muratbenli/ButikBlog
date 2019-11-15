using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ButikBlog.Areas.Admin.ViewModels
{
    public class PostEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "İçerik")]
        public string Content { get; set; }

        [StringLength(200)]
        [Display(Name ="Kısa URL")]
        public string Slug { get; set; }
    }
}