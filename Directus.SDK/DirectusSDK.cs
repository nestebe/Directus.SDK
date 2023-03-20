using Directus.SDK.Authentication;
using Directus.SDK.Clients;

namespace Directus.SDK
{
    public class DirectusSDK
    {
        public readonly ItemsClient Items;
        public readonly FilesClient Files;
        public readonly CollectionsClient Collections;
        // Ajoutez d'autres clients Directus selon vos besoins

        public DirectusSDK(string apiUrl, TokenProvider tokenProvider)
        {
            Items = new ItemsClient(apiUrl, tokenProvider);
            Files = new FilesClient(apiUrl, tokenProvider);
            Collections = new CollectionsClient(apiUrl, tokenProvider);
            // Initialisez d'autres clients Directus selon vos besoins
        }
    }
}