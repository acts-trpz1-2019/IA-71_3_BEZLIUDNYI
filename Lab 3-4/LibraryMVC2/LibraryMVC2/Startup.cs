using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryMVC2.Startup))]
namespace LibraryMVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
