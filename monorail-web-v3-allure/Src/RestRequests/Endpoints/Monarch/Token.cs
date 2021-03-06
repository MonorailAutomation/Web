using Newtonsoft.Json.Linq;
using RestSharp;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch
{
    public static class Token
    {
        private const string TokenEndpoint = "/api/token";

        public static string GenerateToken(string user)
        {
            var client = new RestClient(MonarchAppUri);
            var request = new RestRequest
            {
                Resource = TokenEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new {email = user, password = ValidPassword});

            var response = client.Execute(request);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.accessToken;
        }
    }
}