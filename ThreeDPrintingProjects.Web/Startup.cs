using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThreeDPrintingProjects.Web.Startup))]
namespace ThreeDPrintingProjects.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
