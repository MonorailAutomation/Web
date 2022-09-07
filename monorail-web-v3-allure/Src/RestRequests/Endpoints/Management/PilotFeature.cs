using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Management
{
    public static class PilotFeature
    {
        private const string PilotFeatureEndpoint = "/api/System/PilotFeatures";

        public static void PostPilotFeatures(string userEmail, string featureType)
        {
            var client = new RestClient(MonarchManagementUri)
            {
                //BaseUrl = MonarchManagementUri
            };
            var request = new RestRequest
            {
                Resource = PilotFeatureEndpoint,
                Method = Method.Post,
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("apiKey", GetEndpointConfiguration().MonarchApiKey);
            request.AddJsonBody(new
            {
                userEmail,
                type = featureType,
                isActive = true
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}