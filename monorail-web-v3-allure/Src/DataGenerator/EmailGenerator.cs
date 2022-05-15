using static monorail_web_v3.DataGenerator.DateGenerator;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.VerifyEmailAddress;
using static monorail_web_v3.DataGenerator.NumberGenerator;

namespace monorail_web_v3.DataGenerator
{
    public static class EmailGenerator
    {
        public static string GenerateNewEmail(string usernamePrefix, string usernameSuffix)
        {
            string username;
            bool emailAlreadyExists;
            do
            {
                username = usernamePrefix + GetCurrentDatePlain() + "." + GenerateRandomDigits(4) + usernameSuffix;
                emailAlreadyExists = VerifyEmailAlreadyExists(username);
            } while (emailAlreadyExists);

            return username;
        }
    }
}