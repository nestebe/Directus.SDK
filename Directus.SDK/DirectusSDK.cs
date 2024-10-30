using Directus.SDK.Authentication;
using Directus.SDK.Clients;

namespace Directus.SDK
{
    public class DirectusSDK
    {
        public readonly ItemsClient Items;
        public readonly FilesClient Files;
        public readonly CollectionsClient Collections;

        public DirectusSDK(string apiUrl, TokenProvider tokenProvider)
        {
            Items = new ItemsClient(apiUrl, tokenProvider);
            Files = new FilesClient(apiUrl, tokenProvider);
            Collections = new CollectionsClient(apiUrl, tokenProvider);
        }
    }
}