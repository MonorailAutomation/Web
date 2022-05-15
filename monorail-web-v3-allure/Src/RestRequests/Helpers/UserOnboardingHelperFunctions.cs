using System;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.Token;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.Register;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.RegisterVerify;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.TermsOfUse;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class UserOnboardingHelperFunctions
    {
        public static void RegisterUser(string username)
        {
            PostRegister(username, ValidPhoneNumber, ValidDateOfBirthYmd);
            var token = GenerateToken(username);
            PostRegisterVerify(token);
            var termsOfUseId = GetTermsOfUseId(token);
            PostTermsOfUse(token, termsOfUseId);
            Console.WriteLine(username + " was created successfully");
        }

        public static void RegisterUserWithDoB(string username, string dateOfBirth)
        {
            PostRegister(username, ValidPhoneNumber, dateOfBirth);
            var token = GenerateToken(username);
            PostRegisterVerify(token);
            var termsOfUseId = GetTermsOfUseId(token);
            PostTermsOfUse(token, termsOfUseId);
            Console.WriteLine(username + " was created successfully");
        }
    }
}