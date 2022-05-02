using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests
{
    public static class Wishlists
    {
        private const string WishlistsEndpoint = "/api/Wishlists/";
        private const string WishlistEndpoint = "/api/Wishlist/";

        public static void DeleteWishlists(string token, string wishlistItemId)
        {
            var resource = WishlistsEndpoint + wishlistItemId;
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.DELETE
            };
            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static string AddWishlists(string token, string itemUrlAdd)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new
            {
                itemURL = itemUrlAdd
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.id;
        }

        public static void UpdateWishlists(string token, string amountAdd, string descriptionAdd, string faviconUrlAdd,
            string imageUrlAdd, string itemUrlAdd, string nameAdd, string wishlistItemId)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.PUT,
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new
            {
                amount = amountAdd,
                description = descriptionAdd,
                faviconURL = faviconUrlAdd,
                imageURL = imageUrlAdd,
                itemURL = itemUrlAdd,
                name = nameAdd,
                id = wishlistItemId
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static void AddCustomWishlistItem(string token, string productUrl, string itemName,
            string itemDescription,
            string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new
            {
                itemUrl = productUrl,
                name = itemName,
                description = itemDescription,
                amount = itemAmount,
                imageUrl = itemImageUrl,
                favIconUrl = itemFavIconUrl
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static string[] GetWishlistItemsInProgress(string token)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistEndpoint,
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            dynamic responseContent = JObject.Parse(response.Content);

            string[] wishlistItemsInProgress = responseContent.wishlistItemsInProgress.ToObject<string[]>();

            return wishlistItemsInProgress;
        }
    }
}