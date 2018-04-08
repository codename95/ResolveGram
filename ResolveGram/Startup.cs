using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResolveGram.Startup))]
namespace ResolveGram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
