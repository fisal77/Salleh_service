using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(sallemService.Startup))]

namespace sallemService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}