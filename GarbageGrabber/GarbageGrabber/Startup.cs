using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarbageGrabber.Startup))]
namespace GarbageGrabber
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
            CreateSeedUsers();
        }
    }
}
