using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ButikBlog.Models
{
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Author")]
        [Display(Name = "Yazar")]
        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name ="Url")]
        [StringLength(200)]
        public string Slug { get; set; }

        [Display(Name = "İçerik")]
        public string Content { get; set; }

        [Required]
        public DateTime? CreationTime { get; set; }


        public virtual ApplicationUser Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}