using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEOUrl.Startup))]
namespace SEOUrl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
