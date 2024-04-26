﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
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
                Scopes={"CatalogFullPermission","CatalogReadPermission"}
            },

            new ApiResource("ResourceDiscount")
            {
                Scopes={"DiscountFullPermission","DiscountReadPermission"}
            },

            new ApiResource("ResourceOrder")
            {
                Scopes={"OrderFullPermission","OrderReadPermission"}
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)


        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            //Full permission
            new ApiScope("CatalogFullPermission","Full authorization for category operations."),
            new ApiScope("DiscountFullPermission","Full authorization for discount operations."),
            new ApiScope("OrderFullPermission","Full authorization for order operations."),

            //Read permission
            new ApiScope("CatalogReadPermission","Read authorization for category operations."),
            new ApiScope("DiscountReadPermission","Read authorization for discount operations."),
            new ApiScope("OrderReadPermission","Read authorization for order operations."),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visiter
            new Client
            {
                ClientId="MultiShopVisiterId",
                ClientName="Mutli Shop Visiter User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={ new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "DiscountReadPermission" } 
            },
            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Mutli Shop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={ new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission" , "CatalogReadPermission" }
            },
            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Mutli Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={ new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission" , "CatalogReadPermission" ,
                    "DiscountFullPermission","OrderFullPermission"
                    ,IdentityServerConstants.LocalApi.ScopeName
                    ,IdentityServerConstants.StandardScopes.Email
                    ,IdentityServerConstants.StandardScopes.OpenId
                    ,IdentityServerConstants.StandardScopes.Profile

                },
                AccessTokenLifetime=600
            }
        };
    }
}