using System;
using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.RestRequests
{
    public static class RegisterVerify
    {
        private static readonly Uri RegisterEndpoint =
            new Uri("https://monarch-app-uat.azurewebsites.net/api/v2/user/Register/Verify");

        public static void PostRegisterVerify(string token)
        {
            const string verificationMode = "phone";
            const string verificationCode = "111111";
            var client = new RestClient
            {
                BaseUrl = RegisterEndpoint,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
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

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}