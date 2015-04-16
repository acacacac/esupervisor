using Microsoft.Owin;
using Owin;
[assembly: OwinStartupAttribute(typeof(eSupervisor_Beta.Startup))]
namespace eSupervisor_Beta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();   
        }
    }
}
