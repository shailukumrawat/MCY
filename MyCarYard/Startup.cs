using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCarYard.Startup))]
namespace MyCarYard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //ConfigureAuth(app);

        }
    }
}
