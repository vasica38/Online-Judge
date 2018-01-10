using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Judge.Startup))]
namespace Judge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
