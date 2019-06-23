using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amw.Identity.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").GetAwaiter().GetResult();
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }
            var token1 = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "wechat"
            }).GetAwaiter().GetResult();
            if (token1.IsError)
            {
                Console.WriteLine(token1.Error);
            }
            Console.WriteLine(token1.Json);
            var result1 = TokenGet(token1.AccessToken);
            Console.WriteLine(JArray.Parse(result1.Item2));
            Console.WriteLine();

            var token2 = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "wechat",

                UserName = "tearer",
                Password = "123456"
            }).GetAwaiter().GetResult();

            if (token2.IsError)
            {
                Console.WriteLine(token2.Error);
            }
            Console.WriteLine(token2.Json);
            var result2 = TokenGet(token2.AccessToken);
            Console.WriteLine(JArray.Parse(result2.Item2));
            Console.WriteLine();

            Console.ReadLine();
        }

        public static Tuple<HttpStatusCode, string> TokenGet(string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var response = client.GetAsync("http://localhost:59891/api/mp_jssdk").GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return new Tuple<HttpStatusCode, string>(response.StatusCode, response.ReasonPhrase);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return new Tuple<HttpStatusCode, string>( HttpStatusCode.OK, content);
            }
        }
    }
}