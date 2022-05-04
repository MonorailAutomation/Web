using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch
{
    public static class RegisterVerify
    {
        private const string RegisterEndpoint = "/api/v2/user/Register/Verify";

        public static void PostRegisterVerify(string token)
        {
            const string verificationMode = "phone";
            const string verificationCode = "111111";
            var client = new RestClient
            {
                BaseUrl = MonorailAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = RegisterEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                otp = verificationCode,
                verificationMode,
                primaryInput = ValidPhoneNumber
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}