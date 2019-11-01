namespace ButikBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ButikBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ButikBlog.Models.ApplicationDbContext";
        }

        protected override void Seed(ButikBlog.Models.ApplicationDbContext context)
        {
            
        }
    }
}
