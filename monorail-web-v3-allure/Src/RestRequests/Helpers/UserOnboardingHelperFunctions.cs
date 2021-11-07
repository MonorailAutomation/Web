using System;
using static monorail_web_v3.RestRequests.Token;
using static monorail_web_v3.RestRequests.Register;
using static monorail_web_v3.RestRequests.RegisterVerify;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class UserOnboardingHelperFunctions
    {
        public static void RegisterUser(string username)
        {
            PostRegister(username);
            var token = GenerateToken(username, ValidPassword);
            PostRegisterVerify(token);
            Console.WriteLine(username + " was created successfully");
        }
    }
}