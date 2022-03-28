using System;
using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.RestRequests
{
    public static class PilotFeature
    {
        private const string ApiKey = "0oq1Oj2R6kJNrUX1inqyOjYJtoqbtmJx";

        private static readonly Uri PilotFeatureEndpoint =
            new Uri("https://monarchmanagement-app-" + MonorailEnv + ".azurewebsites.net/api/System/PilotFeatures");

        public static void PostPilotFeatures(string userEmail, string featureType)
        {
            var client = new RestClient
            {
                BaseUrl = PilotFeatureEndpoint
            };
            var request = new RestRequest
            {
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