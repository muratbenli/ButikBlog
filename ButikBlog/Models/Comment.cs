using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ButikBlog.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string AuthorEmail { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime? CreationTime { get; set; }

        public virtual Post Post { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Comment Parent { get; set; }

        public virtual ICollection<Comment> Replies { get; set; }




    }
}