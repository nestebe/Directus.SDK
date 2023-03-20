using Directus.SDK.Authentication;
using Directus.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Clients
{
    public class FilesClient : BaseClient
    {
        public FilesClient(string apiUrl, TokenProvider tokenProvider) : base(apiUrl, tokenProvider)
        {
        }

        public async Task<List<DirectusFile>> GetFilesAsync()
        {
            var response = await GetAsync("files");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var files = JsonConvert.DeserializeObject<List<DirectusFile>>(jsonResponse);
            return files;
        }

        public async Task<DirectusFile> GetFileAsync(string id)
        {
            var response = await GetAsync($"files/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var file = JsonConvert.DeserializeObject<DirectusFile>(jsonResponse);
            return file;
        }

        public async Task<DirectusFile> UploadFileAsync(Stream fileStream, string fileName)
        {
            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            content.Add(fileContent, "file", fileName);

            var response = await PostAsync("files", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var file = JsonConvert.DeserializeObject<DirectusFile>(jsonResponse);
            return file;
        }

        public async Task<DirectusFile> UpdateFileAsync(string id, Dictionary<string, object> fields)
        {
            var content = new StringContent(JsonConvert.SerializeObject(fields), System.Text.Encoding.UTF8, "application/json");
            var response = await PatchAsync($"files/{id}", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var file = JsonConvert.DeserializeObject<DirectusFile>(jsonResponse);
            return file;
        }

        public async Task<bool> DeleteFileAsync(string id)
        {
            var response = await DeleteAsync($"files/{id}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
