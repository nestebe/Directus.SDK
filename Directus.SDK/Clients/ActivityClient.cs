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
    public class ActivityClient : BaseClient
    {
        public ActivityClient(string apiUrl, TokenProvider tokenProvider) : base(apiUrl, tokenProvider)
        {
        }

        public async Task<List<DirectusActivity>> GetActivitiesAsync()
        {
            var response = await GetAsync("activity");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var activities = JsonConvert.DeserializeObject<List<DirectusActivity>>(jsonResponse);
            return activities;
        }

        public async Task<DirectusActivity> GetActivityAsync(string id)
        {
            var response = await GetAsync($"activity/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var activity = JsonConvert.DeserializeObject<DirectusActivity>(jsonResponse);
            return activity;
        }
    }
}
