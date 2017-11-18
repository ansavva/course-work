using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Andreas.Exp.Startup))]
namespace Andreas.Exp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
