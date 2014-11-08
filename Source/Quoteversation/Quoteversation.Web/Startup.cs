using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quoteversation.Web.Startup))]
namespace Quoteversation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
