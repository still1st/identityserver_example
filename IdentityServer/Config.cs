using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[] {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[] {
                new ApiResource("myApi", "My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[] {
                new Client
                {
                    ClientId = "ClientId",
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = { "https://localhost:44393/signin-oidc" },
                    AllowedScopes = { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "myApi" }
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "499C0D46-78B1-4715-95DC-860D4451021A",
                    Username = "Alice",
                    Password = "Password",
                    Claims = new[]
                    {
                        new Claim("given_name", "Alice"),
                        new Claim("family_name", "Wonderland")
                    }
                }
            };
        }
    }
}
