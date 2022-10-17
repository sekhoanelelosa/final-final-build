using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Store_Online.UI.Startup))]
namespace Store_Online.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
