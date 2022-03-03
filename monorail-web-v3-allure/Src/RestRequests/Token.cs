using Newtonsoft.Json.Linq;
using RestSharp;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests
{
    public static class Token
    {
        private const string TokenEndpoint = "/api/token";

        public static string GenerateToken(string user, string pass)
        {
            var client = new RestClient(MonorailUri);
            var request = new RestRequest
            {
                Resource = TokenEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new {email = user, password = pass});

            var response = client.Execute(request);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.accessToken;
        }
    }
}