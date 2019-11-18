using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ButikBlog.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            //varsayilan deger 

            IsEnabled = true;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [StringLength(100)]
        public string Photo { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //bire çoklu ilişkilerde ilişkili satirlarin silinmesini silen convention ı kaldırdık
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Her yorumun zorunlu olarak bir yazisi vardir ve o yazinin da yorumlari vardir yazi silindiginde yorumlarini da otomatik sil
            modelBuilder.Entity<Comment>()
                .HasRequired(x => x.Post)
                .WithMany(x => x.Comments)
                .WillCascadeOnDelete();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}