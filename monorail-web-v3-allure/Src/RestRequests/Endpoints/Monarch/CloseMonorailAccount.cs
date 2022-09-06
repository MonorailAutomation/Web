using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch
{
    public static class CloseMonorailAccount
    {
        private const string CloseMonorailAccountEndpoint = "/api/accounts/monorail/close";

        public static void PostMonorailCloseUser(string token)
        {
            var resource = CloseMonorailAccountEndpoint;
            var client = new RestClient(MonarchAppUri)
            {
                //BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.Post
            };

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}