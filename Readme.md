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
var tokenProvider = new authenticator.TokenProvider(email, password);
var directusSDK = new DirectusSDK(apiUrl, tokenProvider);
```

You can then use the `directusSDKinstance to interact with the various Directus API endpoints.

Here is an example of using the Directus SDK library to retrieve all items in a collection:

```c#
using Newtonsoft.Json;   
public class Blog
{ 
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("content")]
    public string Content { get; set; }
 }

//Create new item
var item = new Blog() { Content= "content_test", Title="title_test" };
var itemCreated = await directusSDK.Items.CreateItemAsync<Blog>("Blog", item);

//Update Item
var itemToUpdate = await directusSDK.Items.GetItemAsync<Blog>("Blog", "item_id");
itemToUpdate.Title = "title_test_2";

var item = await directusSDK.Items.UpdateItemAsync<Blog>("Blog", "item_id", itemToUpdate);

//Delete Item
var isDeleted = await directusSDK.Items.DeleteItemAsync("Blog", "item_id");

//Custom queries
DirectusQueryBuilder queryBuilder = new DirectusQueryBuilder();
var customFilter = new OrFilter(new EqFilter("content", "content_test_2"), new EqFilter("title", "title_test_3"));
queryBuilder.CustomFilter(customFilter);

var items = await directusSDK.Items.GetItemsAsync<Blog>("Blog", queryBuilder);


```

## Contribution

Contributions are welcome! Feel free to open a pull request to propose modifications or additions to the Directus SDK library.

## License

This project is licensed under the MIT license. See the LICENSE file for more information.