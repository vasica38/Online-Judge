using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineJudge1.Startup))]
namespace OnlineJudge1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
