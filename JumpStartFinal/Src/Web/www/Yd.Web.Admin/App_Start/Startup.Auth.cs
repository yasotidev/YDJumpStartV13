using Microsoft.Owin.Security.WindowsAzure;
using Owin;

namespace Yd.Web.Admin
{
    public partial class Startup
    {
        public void ConfigurAuth(IAppBuilder app)
        {
            app.UseWindowsAzureBearerToken(new WindowsAzureJwtBearerAuthenticationOptions()
            {
                Audience = "https://yasotidevwaad.onmicrosoft.com/ApiDefault",
                Tenant = "yasotidevwaad.onmicrosoft.com"
            });
        }
    }
}