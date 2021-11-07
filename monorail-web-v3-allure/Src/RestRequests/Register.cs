using System;
using System.Net;
using FluentAssertions;
using RestSharp;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.RestRequests
{
    public static class Register
    {
        private static readonly Uri RegisterEndpoint =
            new Uri("https://monarch-app-uat.azurewebsites.net/api/v3/user/Register");

        public static void PostRegister(string userEmail)
        {
            const string verificationMode = "phone";
            var client = new RestClient
            {
                BaseUrl = RegisterEndpoint
            };
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                password = ValidPassword,
                verificationMode,
                email = userEmail,
                phoneNumber = ValidPhoneNumber,
                userDateOfBirth = ValidDateOfBirth
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}