using static monorail_web_v3.RestRequests.Endpoints.Monarch.VerifyEmailAddress;
using static monorail_web_v3.Commons.NumberGenerator;

namespace monorail_web_v3.Commons
{
    public static class EmailGenerator
    {
        public static string GenerateNewEmail(string usernamePrefix, string usernameSuffix)
        {
            string username;
            bool emailAlreadyExists;
            do
            {
                username = usernamePrefix + GetCurrentDate() + "." + GenerateRandom4Digits() + usernameSuffix;
                emailAlreadyExists = VerifyEmailAlreadyExists(username);
            } while (emailAlreadyExists);

            return username;
        }
    }
}