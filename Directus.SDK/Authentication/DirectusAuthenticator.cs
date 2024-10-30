using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Authentication
{
    public class DirectusAuthenticator : IDisposable
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public DirectusAuthenticator(string apiUrl)
        {
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
        }

        public async Task<TokenProvider> AuthenticateAsync(string email, string password)
        {
            var requestUrl = $"{_apiUrl}/auth/login";
            var content = new StringContent(JsonConvert.SerializeObject(new { email, password }), Encoding.UTF8, "application/json");
            var token = new TokenProvider();
            using var response = await _httpClient.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<JObject>(jsonResponse);
                var accessToken = authResponse["data"]["access_token"].ToString();
                token.SetAccessToken(accessToken);
                return token;
            }
            else
            {
                throw new Exception($"Authentication failed with status code: {response.StatusCode}");
            }
        }

        public async Task<TokenProvider> AuthenticateAsync(string staticToken)
        {
            var token = new TokenProvider();
            token.SetAccessToken(staticToken);
            return token;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
