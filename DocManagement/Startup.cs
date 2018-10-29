using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocManagement.Startup))]
namespace DocManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
