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
    }
}