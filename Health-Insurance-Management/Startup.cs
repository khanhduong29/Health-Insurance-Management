using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Health_Insurance_Management.Startup))]
namespace Health_Insurance_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
