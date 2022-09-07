using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch
{
    public static class Wishlists
    {
        private const string WishlistsEndpoint = "/api/Wishlists/";

        public static void DeleteWishlists(string token, string wishlistItemId)
        {
            var resource = WishlistsEndpoint + wishlistItemId;
            var client = new RestClient(MonarchAppUri)
            {
                //BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.Delete
            };
            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static void UpdateWishlists(string token, string amountAdd, string descriptionAdd, string faviconUrlAdd,
            string imageUrlAdd, string itemUrlAdd, string nameAdd, string wishlistItemId)
        {
            var client = new RestClient(MonarchAppUri)
            {
                //BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.Put,
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

        public static string AddCustomWishlistItem(string token, string productUrl, string itemName,
            string itemDescription,
            string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var client = new RestClient(MonarchAppUri)
            {
                //BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.Post,
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

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.id;
        }
    }
}