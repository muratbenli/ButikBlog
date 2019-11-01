using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ButikBlog.Startup))]
namespace ButikBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
