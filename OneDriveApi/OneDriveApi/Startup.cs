using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneDriveDeneme_23_02_2018.Startup))]
namespace OneDriveDeneme_23_02_2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
