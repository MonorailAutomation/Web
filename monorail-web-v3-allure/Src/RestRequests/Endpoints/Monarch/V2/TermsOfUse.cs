using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch.V2
{
    public static class TermsOfUse
    {
        private const string DocumentsEndpoint = "/api/v2/documents?documentType=termsOfUse";

        public static string GetTermsOfUseId(string token)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = DocumentsEndpoint,
                Method = Method.GET
            };
            request.AddHeader("product", "iOS");

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.documentId;
        }

        public static void PostTermsOfUse(string token, string termsOfUseId)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = DocumentsEndpoint,
                Method = Method.POST
            };
            request.AddJsonBody(new
            {
                documentId = termsOfUseId,
                viewed = true,
                accepted = true
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}