using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAdvance01.Startup))]
namespace MvcAdvance01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
