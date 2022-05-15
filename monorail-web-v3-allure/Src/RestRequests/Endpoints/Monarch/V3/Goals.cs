using System;
using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch.V3
{
    public static class Goals
    {
        private const string GoalsEndpoint = "/api/v3/Goals/";

        public static void PatchGoals(string token, string goalId, string goalDescription, string goalName)
        {
            var resource = GoalsEndpoint + goalId;
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.PATCH,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new {itemDescription = goalDescription, name = goalName});

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static void PutGoals(string token, string goalId, string balance, string date)
        {
            var resource = GoalsEndpoint + goalId;
            var convertedDate = Convert.ToDateTime(date).ToString("yyyy-MM-ddTHH:mm:ssZ");

            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };

            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.PUT,
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new {targetBalance = balance, targetDate = convertedDate});

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}