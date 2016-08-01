using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeSheet2017.Startup))]
namespace TimeSheet2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
