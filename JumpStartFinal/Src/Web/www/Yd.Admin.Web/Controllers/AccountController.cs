using System;
using System.IdentityModel.Services;
using System.IdentityModel.Services.Configuration;
using System.Web.Mvc;

namespace Yd.Admin.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignOut()
        {
            WsFederationConfiguration config = FederatedAuthentication.FederationConfiguration.WsFederationConfiguration;

            // Redirigez vers SignOutCallback après la déconnexion.
            string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);
            SignOutRequestMessage signoutMessage = new SignOutRequestMessage(new Uri(config.Issuer), callbackUrl);
            signoutMessage.SetParameter("wtrealm", IdentityConfig.Realm ?? config.Realm);
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            return new RedirectResult(signoutMessage.WriteQueryString());
        }

        public ActionResult SignOutCallback()
        {
            if (Request.IsAuthenticated)
            {
                // Redirigez vers la page d’accueil si l’utilisateur est authentifié.
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
