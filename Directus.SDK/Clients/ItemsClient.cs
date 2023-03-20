using Directus.SDK.Authentication;
using Directus.SDK.Models;
using Directus.SDK.Resolvers;
using Directus.SDK.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Clients
{
    public class ItemsClient : BaseClient
    {
        public ItemsClient(string apiUrl, TokenProvider tokenProvider) : base(apiUrl, tokenProvider)
        {
        }

        public async Task<List<T>> GetItemsAsync<T>(string collection)
        {
            var response = await GetAsync($"items/{collection}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<DirectusResponse<List<T>>>(jsonResponse);
            return items.Data;
        }

        public async Task<T> GetItemAsync<T>(string collection, string id)
        {
            var response = await GetAsync($"items/{collection}/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<DirectusResponse<T>>(jsonResponse);
            return item.Data;
        }
        public async Task<List<T>> GetItemsAsync<T>(string collection, DirectusQueryBuilder queryBuilder = null)
        {
            var requestUrl = $"items/{collection}";

            if (queryBuilder != null)
            {
                requestUrl += "?" + queryBuilder.Build();
            }

            var response = await GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<DirectusResponse<List<T>>>(jsonResponse);
            return items.Data;
        }

        public async Task<T> CreateItemAsync<T>(string collection, T item)
        {
            // Créez un objet de paramètres de sérialisation spécifique
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreIdPropertyResolver()
            };

            var content = new StringContent(JsonConvert.SerializeObject(item, settings), Encoding.UTF8, "application/json");
            var response = await PostAsync($"items/{collection}", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var itemCreated = JsonConvert.DeserializeObject<DirectusResponse<T>>(jsonResponse);
            return itemCreated.Data;
        }


        public async Task<T> UpdateItemAsync<T>(string collection, string id, T item)
        {
            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            var response = await PatchAsync($"items/{collection}/{id}", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var itemUpdated = JsonConvert.DeserializeObject<DirectusResponse<T>>(jsonResponse);
            return itemUpdated.Data;
        }

        public async Task<bool> DeleteItemAsync(string collection, string id)
        {
            var response = await DeleteAsync($"items/{collection}/{id}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
