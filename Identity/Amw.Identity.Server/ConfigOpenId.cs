using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace Amw.Identity.Server
{
    public class ConfigOpenId
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var identityResources = new List<IdentityResource>();
            var identityResource = new IdentityResources.OpenId();
            identityResources.Add(identityResource);
            return identityResources;
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            var resources = new List<ApiResource>();
            var resource = new ApiResource("wechat", "Wechat");
            resources.Add(resource);
            return resources;
        }

        public static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>();
            var client = new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AccessTokenLifetime = 60 * 60 * 24 * 180,//半年
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "wechat" }
            };
            clients.Add(client);
            return clients;
        }
    }
}