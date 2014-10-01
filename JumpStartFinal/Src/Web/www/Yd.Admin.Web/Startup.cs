using Owin;

namespace Yd.Admin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);

            ConfigureSignalR(app);
        }
    }
}