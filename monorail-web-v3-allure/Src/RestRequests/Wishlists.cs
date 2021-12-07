using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests
{
    public static class Wishlists
    {
        private const string WishlistsEndpoint = "/api/Wishlists/";

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

        public static void AddWishlists(string token, string amountAdd, string descriptionAdd, string faviconUrlAdd,
            string imageUrlAdd, string itemUrlAdd, string nameAdd)
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
                amount = amountAdd,
                description = descriptionAdd,
                faviconURL = faviconUrlAdd,
                imageURL = imageUrlAdd,
                itemURL = itemUrlAdd,
                name = nameAdd
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static void RevertWishlists(string token, string amountAdd, string descriptionAdd, string faviconUrlAdd,
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
    }
}