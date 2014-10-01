using System.IdentityModel.Tokens;
using System.Linq;
using Yd.Server.Core.Data;

namespace Yd.Admin.Web.Core
{
    public class SingleTenantIssuerNameRegistry : ValidatingIssuerNameRegistry
    {
        public static bool ContainsTenant(string tenantId)
        {
            using (var context = new YdAdventureContext())
            {
                return context.Tenants
                    .Where(tenant => tenant.Id == tenantId)
                    .Any();
            }
        }

        public static bool ContainsKey(string thumbprint)
        {
            using (var context = new YdAdventureContext())
            {
                return context.IssuingAuthorityKeys
                    .Where(key => key.Id == thumbprint)
                    .Any();
            }
        }

        public static void RefreshKeys(string metadataLocation)
        {
            var issuingAuthority = ValidatingIssuerNameRegistry.GetIssuingAuthority(metadataLocation);

            var newKeys = false;
            var refreshTenant = false;
            foreach (var thumbprint in issuingAuthority.Thumbprints)
            {
                if (!ContainsKey(thumbprint))
                {
                    newKeys = true;
                    refreshTenant = true;
                    break;
                }
            }

            foreach (var issuer in issuingAuthority.Issuers)
            {
                if (!ContainsTenant(GetIssuerId(issuer)))
                {
                    refreshTenant = true;
                    break;
                }
            }

            if (newKeys || refreshTenant)
            {
                using (var context = new YdAdventureContext())
                {
                    if (newKeys)
                    {
                      context.IssuingAuthorityKeys.RemoveRange(context.IssuingAuthorityKeys);
                      foreach (var thumbprint in issuingAuthority.Thumbprints)
                      {
                          context.IssuingAuthorityKeys.Add(new IssuingAuthorityKey { Id = thumbprint });
                      }
                    }

                    if (refreshTenant)
                    {
                        foreach (var issuer in issuingAuthority.Issuers)
                        {
                            var issuerId = GetIssuerId(issuer);
                            if (!ContainsTenant(issuerId))
                            {
                                context.Tenants.Add(new Tenant { Id = issuerId });
                            }
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private static string GetIssuerId(string issuer)
        {
            return issuer.TrimEnd('/').Split('/').Last();
        }

        protected override bool IsThumbprintValid(string thumbprint, string issuer)
        {
            return ContainsTenant(GetIssuerId(issuer))
                && ContainsKey(thumbprint);
        }
    }
}
