using Directus.SDK.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Clients
{

    public class BaseClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly TokenProvider _tokenProvider;
        protected readonly string _apiUrl;

        public BaseClient(string apiUrl, TokenProvider tokenProvider)
        {
            _apiUrl = apiUrl;
            _tokenProvider = tokenProvider;
            _httpClient = new HttpClient();
        }

        protected async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            PrepareRequestHeaders();
            return await _httpClient.GetAsync(new Uri($"{_apiUrl}/{endpoint}"));
        }

        protected async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent content)
        {
            PrepareRequestHeaders();
            return await _httpClient.PostAsync(new Uri($"{_apiUrl}/{endpoint}"), content);
        }

        protected async Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent content)
        {
            PrepareRequestHeaders();
            return await _httpClient.PutAsync(new Uri($"{_apiUrl}/{endpoint}"), content);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            PrepareRequestHeaders();
            return await _httpClient.DeleteAsync(new Uri($"{_apiUrl}/{endpoint}"));
        }

        protected async Task<HttpResponseMessage> PatchAsync(string endpoint, HttpContent content)
        {
            PrepareRequestHeaders();
            return await _httpClient.PatchAsync(new Uri($"{_apiUrl}/{endpoint}"), content);
        }

        private void PrepareRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenProvider.GetAccessToken());
        }
    }
}