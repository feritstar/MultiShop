// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = {"CatalogFullPermission","CatalogReadPermission","CatalogWritePermission"}
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = {"DiscountFullPermission","DiscountReadPermission","DiscountWritePermission"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = {"OrderFullPermission","OrderReadPermission","OrderDeletePermission","OrderEditPermission"}
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] 
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog operations"),
            new ApiScope("CatalogWritePermission", "Writing authority for catalog operations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("DiscountReadPermission", "Reading authority for discount operations"),
            new ApiScope("DiscountWritePermission", "Writing authority for discount operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations"),
            new ApiScope("OrderReadPermission", "Reading authority for order operations"),
            new ApiScope("OrderDeletePermission", "Deletion authority for order operations"),
            new ApiScope("OrderEditPermission", "Editing authority for order operations"),
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission" }
            },
            // Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission"}
            },
            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants .StandardScopes.Email,
                IdentityServerConstants .StandardScopes.OpenId,
                IdentityServerConstants .StandardScopes.Profile
                },
                AccessTokenLifetime = 600 // 600 seconds = 10 minutes
            }
        };

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //           new IdentityResource[]
        //           {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //           };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //    new ApiScope[]
        //    {
        //        new ApiScope("scope1"),
        //        new ApiScope("scope2"),
        //    };

        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
    }
}