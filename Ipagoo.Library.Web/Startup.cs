using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ipagoo.Library.Web.Startup))]
namespace Ipagoo.Library.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
