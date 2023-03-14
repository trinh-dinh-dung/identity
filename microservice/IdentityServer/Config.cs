// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api_service", "Service API"),
            };

        public static IEnumerable<Client> Clients =>

             new List<Client>
             {
                 //new Client
                 //  {
                 //      ClientId = "admin",
                 //      ClientName = "evo mes admin client mvc",
                 //      AllowedGrantTypes = GrantTypes.Code,
                 //      RequirePkce = false,
                 //      ClientSecrets = new List<Secret>
                 //      {
                 //           new Secret("secret".Sha256())
                 //      },
                 //      RedirectUris = new List<string>()
                 //      {
                 //          "https://localhost:44350/signin-oidc"
                 //      },
                 //      PostLogoutRedirectUris = new List<string>()
                 //      {
                 //          "https://localhost:44350/signout-callback-oidc"
                 //      },


                 //      AllowedScopes = new List<string>
                 //      {
                 //          IdentityServerConstants.StandardScopes.OpenId,
                 //          IdentityServerConstants.StandardScopes.Profile,
                 //          IdentityServerConstants.StandardScopes.Address,
                 //          IdentityServerConstants.StandardScopes.Email,
                 //          "offline_access",
                 //          "roles"
                 //      },
                 //       AllowOfflineAccess = true,
                 //       AbsoluteRefreshTokenLifetime = 2592000, // 30 day
                 //       SlidingRefreshTokenLifetime = 1296000, // refresh token 15 day
                 //       AccessTokenLifetime = 3600 // access_token 1h

                 //  },
                 // interactive ASP.NET Core MVC client
                new Client
                {

                    ClientId = "ReactApp",
                    ClientName = "ReactApp tract app",
                    AllowedGrantTypes = GrantTypes.Code,
                    //RequireClientSecret = false,

                    RequirePkce = false,

                    ClientSecrets = new List<Secret>
                       {
                            new Secret("secret".Sha256())
                       },
                    RedirectUris = new List<string>()
                       {
                           "http://localhost:3000/signin-oidc"
                       },
                     PostLogoutRedirectUris = new List<string>()
                       {
                           "http://localhost:3000/signout-oidc"
                       },

                    AllowedCorsOrigins =     { "http://localhost:3000" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "offline_access",
                        "api_service"
                    },
                    AllowOfflineAccess = true,
                    AbsoluteRefreshTokenLifetime = 2592000, // 30 day
                    SlidingRefreshTokenLifetime = 1296000, // refresh token 15 day
                    AccessTokenLifetime = 3600 // access_token 1h

                },
             };
    }
}

