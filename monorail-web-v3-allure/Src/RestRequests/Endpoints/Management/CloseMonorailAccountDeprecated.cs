using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Management
{
    public static class CloseMonorailAccountDeprecated
    {
        private const string CloseMonorailAccountEndpoint = "/api/intervention/accounts/monorail/close/";

        public static void PostMonorailCloseUserId(string userId)
        {
            var resource = CloseMonorailAccountEndpoint + userId;
            var client = new RestClient(MonarchManagementUri)
            {
                //BaseUrl = MonarchManagementUri
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.Post
            };
            request.AddHeader("apiKey", GetEndpointConfiguration().MonarchApiKey);

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}