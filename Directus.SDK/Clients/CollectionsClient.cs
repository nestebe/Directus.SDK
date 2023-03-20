using Directus.SDK.Authentication;
using Directus.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Clients
{
    public class CollectionsClient : BaseClient
    {
        public CollectionsClient(string apiUrl, TokenProvider tokenProvider) : base(apiUrl, tokenProvider)
        {
        }

        public async Task<List<DirectusCollection>> GetCollectionsAsync()
        {
            var response = await GetAsync("collections");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var collections = JsonConvert.DeserializeObject<List<DirectusCollection>>(jsonResponse);
            return collections;
        }

        public async Task<DirectusCollection> GetCollectionAsync(string name)
        {
            var response = await GetAsync($"collections/{name}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var collection = JsonConvert.DeserializeObject<DirectusCollection>(jsonResponse);
            return collection;
        }

        public async Task<DirectusCollection> CreateCollectionAsync(DirectusCollection collection)
        {
            var content = new StringContent(JsonConvert.SerializeObject(collection), System.Text.Encoding.UTF8, "application/json");
            var response = await PostAsync("collections", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var createdCollection = JsonConvert.DeserializeObject<DirectusCollection>(jsonResponse);
            return createdCollection;
        }

        public async Task<DirectusCollection> UpdateCollectionAsync(string name, Dictionary<string, object> fields)
        {
            var content = new StringContent(JsonConvert.SerializeObject(fields), System.Text.Encoding.UTF8, "application/json");
            var response = await PatchAsync($"collections/{name}", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var updatedCollection = JsonConvert.DeserializeObject<DirectusCollection>(jsonResponse);
            return updatedCollection;
        }

        public async Task<bool> DeleteCollectionAsync(string name)
        {
            var response = await DeleteAsync($"collections/{name}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
