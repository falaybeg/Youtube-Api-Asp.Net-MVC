using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YoutubeSampleApiApp.Startup))]
namespace YoutubeSampleApiApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
