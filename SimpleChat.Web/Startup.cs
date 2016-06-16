using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleChat.Web.Startup))]
namespace SimpleChat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
