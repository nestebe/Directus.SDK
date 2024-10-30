using Directus.SDK.Authentication;
using Directus.SDK;
using DotNetEnv;
using Directus.SDK.Models;
using Directus.SDK.Utils;

namespace DIrectus.SDK.Tests
{
    [TestFixture]
    public class ItemsTests
    {
        private string _token;
        private string _password;
        private string _baseUrl;
        private DirectusSDK directusSDK;
        private string lastId;

        [SetUp]
        public async Task SetUp()
        {
            Env.Load();
            _token = Environment.GetEnvironmentVariable("TEST_TOKEN");
            _baseUrl = Environment.GetEnvironmentVariable("TEST_URL");


            var tokenProvider = new TokenProvider();
            tokenProvider.SetAccessToken(_token);

            directusSDK = new DirectusSDK(_baseUrl, tokenProvider);
        }

        [Test, Order(1)]
        public async Task Test_CreateItem()
        {
            var item = new Blog() { Content= "content_test", Title="title_test" };
            var itemCreated = await directusSDK.Items.CreateItemAsync<Blog>("blog", item);
            lastId = itemCreated.Id;
            Assert.IsNotNull(itemCreated);
            Assert.IsNotEmpty(itemCreated.Id);
            Assert.IsTrue("title_test".Equals(itemCreated.Title));
            Assert.IsTrue("content_test".Equals(itemCreated.Content));
        }

        [Test, Order(2)]
        public async Task Test_GetItemById()
        {
            var item = await directusSDK.Items.GetItemAsync<Blog>("blog", lastId);

            Assert.IsNotNull(item);
            Assert.IsNotEmpty(item.Id);
            Assert.IsTrue("title_test".Equals(item.Title));
            Assert.IsTrue("content_test".Equals(item.Content));
        }

        [Test, Order(3)]
        public async Task Test_UpdateItem()
        {

            var itemToUpdate = await directusSDK.Items.GetItemAsync<Blog>("blog", lastId);
            itemToUpdate.Title = "title_test_2";

            var item = await directusSDK.Items.UpdateItemAsync<Blog>("blog", lastId, itemToUpdate);

            Assert.IsNotNull(item);
            Assert.IsNotEmpty(item.Id);
            Assert.IsTrue("title_test_2".Equals(item.Title));

        }
        [Test, Order(4)]
        public async Task Test_DeleteItem()
        {
            var isDeleted = await directusSDK.Items.DeleteItemAsync("blog", lastId);
            Assert.IsTrue(isDeleted);
        }


        [Test, Order(5)]
        public async Task Test_Queries()
        {
      
            var item1 =  await directusSDK.Items.CreateItemAsync<Blog>("blog", new Blog() { Content = "content_test_1", Title = "title_test_1" });
            var item2 = await directusSDK.Items.CreateItemAsync<Blog>("blog", new Blog() { Content = "content_test_2", Title = "title_test_2" });
            var item3 = await directusSDK.Items.CreateItemAsync<Blog>("blog", new Blog() { Content = "content_test_3", Title = "title_test_3" });

            DirectusQueryBuilder queryBuilder = new DirectusQueryBuilder();
            var customFilter = new OrFilter(new EqFilter("content", "content_test_2"), new EqFilter("title", "title_test_3"));
            queryBuilder.CustomFilter(customFilter);

            var items = await directusSDK.Items.GetItemsAsync<Blog>("blog", queryBuilder);

            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count == 2);

            DirectusQueryBuilder queryBuilder2 = new DirectusQueryBuilder();

            await directusSDK.Items.DeleteItemAsync("blog", item1.Id);
            await directusSDK.Items.DeleteItemAsync("blog", item2.Id);
            await directusSDK.Items.DeleteItemAsync("blog", item3.Id);

        }
    }
}