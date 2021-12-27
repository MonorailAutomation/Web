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
            PostRegister(username, ValidPhoneNumber, ValidDateOfBirthYmd);
            var token = GenerateToken(username, ValidPassword);
            PostRegisterVerify(token);
            Console.WriteLine(username + " was created successfully");
        }
        
        public static void RegisterUserWithDoB(string username, string dateOfBirth)
        {
            PostRegister(username, ValidPhoneNumber, dateOfBirth);
            var token = GenerateToken(username, ValidPassword);
            PostRegisterVerify(token);
            Console.WriteLine(username + " was created successfully");
        }
        
        public static void RegisterUserWithPhoneNumber(string username, string phoneNumber)
        {
            PostRegister(username, phoneNumber, ValidDateOfBirthYmd);
            var token = GenerateToken(username, ValidPassword);
            PostRegisterVerify(token);
            Console.WriteLine(username + " was created successfully");
        }
        
        public static void RegisterUserWithPhoneNumberAndDateOfBirth(string username, string phoneNumber, string dateOfBirth)
        {
            PostRegister(username, phoneNumber, dateOfBirth);
            var token = GenerateToken(username, ValidPassword);
            PostRegisterVerify(token);
            Console.WriteLine(username + " was created successfully");
        }
    }
}