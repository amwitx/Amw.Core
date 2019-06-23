using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace Amw.Identity.Server
{
    public class ConfigPassword
    {
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
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AccessTokenLifetime = 60 * 60 * 24 * 180,//半年
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "wechat" }
            };
            clients.Add(client);
            return clients;
        }

        public static List<TestUser> GetUsers() {
            var users = new List<TestUser>();
            var user1 = new TestUser {
                //用户唯一标识
                SubjectId = "1",
                Username="tearer",
                Password="123456"
            };
            users.Add(user1);
            var user2 = new TestUser
            {
                SubjectId = "2",
                Username = "zero",
                Password = "123456"
            };
            users.Add(user2);
            return users;
        }
    }
}