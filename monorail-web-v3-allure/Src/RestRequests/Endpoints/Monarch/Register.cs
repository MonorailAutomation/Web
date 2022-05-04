using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.RestConfig;

namespace monorail_web_v3.RestRequests.Endpoints.Monarch
{
    public static class Register
    {
        private const string RegisterEndpoint = "/api/v3/user/Register";

        public static void PostRegister(string userEmail, string phoneNo, string dateOfBirth)
        {
            const string verificationMode = "phone";
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri
            };
            var request = new RestRequest
            {
                Resource = RegisterEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                password = ValidPassword,
                verificationMode,
                email = userEmail,
                phoneNumber = phoneNo,
                userDateOfBirth = dateOfBirth
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}