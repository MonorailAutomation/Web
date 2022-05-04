using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Management
{
    public static class PilotFeature
    {
        private const string ApiKey = "0oq1Oj2R6kJNrUX1inqyOjYJtoqbtmJx";
        private const string PilotFeatureEndpoint = "/api/System/PilotFeatures";

        public static void PostPilotFeatures(string userEmail, string featureType)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchManagementUri
            };
            var request = new RestRequest
            {
                Resource = PilotFeatureEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("apiKey", ApiKey);
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