using System.Collections.Generic;
using IdentityServer4.Models;

namespace Identity.Service.Helpers
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                    AllowedScopes = new List<string> {"api1.read"}
                },
                new Client
                {
                    // unique ID for this client
                    ClientId = "wewantdoughnuts", 
                    // human-friendly name displayed in IS
                    ClientName = "We Want Doughnuts", 
                    // URL of client
                    ClientUri = "http://localhost:4200", 
                    // how client will interact with our identity server (Implicit is basic flow for web apps)
                    AllowedGrantTypes = GrantTypes.Implicit, 
                    // don't require client to send secret to token endpoint
                    RequireClientSecret = false,
                    RedirectUris =
                    {             
                        // can redirect here after login                     
                        "http://localhost:4200/signin-oidc",
                    },
                    // can redirect here after logout
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-oidc" }, 
                    // builds CORS policy for javascript clients
                    AllowedCorsOrigins = { "http://localhost:4200" }, 
                    // what resources this client can access
                    AllowedScopes = { "openid", "profile", "email", "api", "doughnutapi" }, 
                    // client is allowed to receive tokens via browser
                    AllowAccessTokensViaBrowser = true
                }

            };
        }
    }
}