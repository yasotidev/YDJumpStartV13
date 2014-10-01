using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace Yd.Web.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigurAuth(app);
             ConfigureSignalR(app);
        }
    }
}