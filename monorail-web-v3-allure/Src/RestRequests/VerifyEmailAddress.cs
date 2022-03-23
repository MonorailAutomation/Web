using System;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests
{
    public static class VerifyEmailAddress
    {
        private const string VerifyEmailAddressEndpoint = "/api/user/VerifyEmailAddress";

        public static bool VerifyEmailAlreadyExists(string userEmail)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri
            };
            var request = new RestRequest
            {
                Resource = VerifyEmailAddressEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                email = userEmail,
            });

            var response = client.Execute(request);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.emailExist;
        }
    }
}