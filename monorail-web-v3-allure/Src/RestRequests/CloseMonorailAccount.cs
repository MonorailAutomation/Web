using System;
using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.RestRequests
{
    public static class CloseMonorailAccount
    {
        private const string ApiKey = "0oq1Oj2R6kJNrUX1inqyOjYJtoqbtmJx";

        private static readonly Uri PilotFeatureEndpoint =
            new Uri("https://monarchmanagement-app-" + MonorailEnv +
                    ".azurewebsites.net/api/intervention/accounts/monorail/close");

        public static void PostMonorailCloseUserId(string userId)
        {
            var client = new RestClient
            {
                BaseUrl = PilotFeatureEndpoint
            };
            var request = new RestRequest
            {
                Resource = userId,
                Method = Method.POST
            };
            request.AddHeader("apiKey", ApiKey);

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}