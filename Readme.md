# Directus 9 .NET SDK

This project is a library for using the Directus API. It provides clients for interacting with the various API endpoints, including items, files, and collections.

## Installation

The Directus SDK library is available on NuGet. You can install it via the Package Manager Console in Visual Studio or via the command line:

```C#
PM> Install-Package Directus.SDK
```

## Work in progress

- [x] Authentification
- [x] Items
- [ ] Files (WIP)
- [ ] Collections (WIP)
- [ ] Dashboards (WIP)
- [ ] Extensions (WIP)
- [ ] Fields (WIP)
- [ ] Flows (WIP)
- [ ] Folders (WIP)
- [ ] Notifications (WIP)
- [ ] Operations (WIP)
- [ ] Panels (WIP)
- [ ] Permissions (WIP)
- [ ] Presets (WIP)
- [ ] Relations (WIP)
- [ ] Revisions (WIP)
- [ ] Roles (WIP)
- [ ] Shema (WIP)
- [ ] Server (WIP)
- [ ] Settings (WIP)
- [ ] Users (WIP)
- [ ] Utilities (WIP)
- [ ] Webhooks (WIP

## Usage

To use the Directus SDK library, you must provide authentication information for your Directus instance. Here is an example configuration:

```c#

var apiUrl = "https://example.com";
var email = "test@example.com";
var password = "password";

//Authentification
var authenticator = new DirectusAuthenticator(apiUrl);
var tokenProvider = new TokenProvider(authenticator, email, password);
var directusSDK = new DirectusSDK(apiUrl, tokenProvider);
```

You can then use the `directusSDKinstance to interact with the various Directus API endpoints.

Here is an example of using the Directus SDK library to retrieve all items in a collection:

```c#
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

	// Get Items
    var items = await directusSdk.Items.GetItemsAsync<Blog>("Blog");

    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title}");
    }

	//Get Item
    var item = await directusSdk.Items.GetItemAsync<Blog>("Blog","item_id");

	//Create new item
    var newPost = await directusSdk.Items.CreateItemAsync<Blog>("Blog", new Blog { Title = "Hello", Content="paragraph"});
	
	//Update Item
  	 var blogUpdated = await itemsClient.UpdateItemAsync<Blog>("Blog", "item_id", item);

	//Delete Item
 	var itemIsDeleted = await itemsClient.DeleteItemAsync("Blog", "item_id");


	//Use Queries
    var queryBuilder = new DirectusQueryBuilder()
    .Fields("id", "title")
    .Limit(10)
    .Offset(0)
    .Sort("title")
    .Filter("title", "hello", "_contains");

    var items =  await directusSdk.Items.GetItemsAsync<Blog>("Blog", queryBuilder);



```

In this example, we used the `itemsClient` to retrieve all items in the "collection_name" collection. We specified the `DirectusItem` type as the generic type for the `GetAllAsync` method, which means that each item will be deserialized into an instance of the `DirectusItem` class.

## Contribution

Contributions are welcome! Feel free to open a pull request to propose modifications or additions to the Directus SDK library.

## License

This project is licensed under the MIT license. See the LICENSE file for more information.