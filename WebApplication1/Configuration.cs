﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace WebApplication1
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NotesWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebAPI", "Web API", new[]
                {
                    JwtClaimTypes.Name
                })

                {
                    Scopes = {"NotesWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "notes-web-api",
                    ClientName = "Notes Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret= false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http:// .../signin-odic"
                    },
                    AllowedCorsOrigins =
                    {
                        "http:// ..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http:/ .../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NotesWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true,
                }
            };
    }
}