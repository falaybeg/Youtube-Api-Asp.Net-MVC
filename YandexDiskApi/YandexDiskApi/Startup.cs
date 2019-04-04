using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YandexDiskApiSample.Startup))]
namespace YandexDiskApiSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
