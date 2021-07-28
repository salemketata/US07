using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(US07.Startup))]
namespace US07
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
