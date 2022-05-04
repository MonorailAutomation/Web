using System;
using static monorail_web_v3.Database.RetrieveUser;
using static monorail_web_v3.RestRequests.Endpoints.AzureFunctions.UserSuspensionFunction;
using static monorail_web_v3.RestRequests.Endpoints.Management.CloseMonorailAccount;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class UserManagementHelperFunctions
    {
        public static void CloseUser(string email)
        {
            var userId = GetUserId(email);
            PostMonorailCloseUserId(userId);
            Console.WriteLine(email + " was closed successfully");
        }

        public static void SuspendUser(string email)
        {
            var userId = GetUserId(email);
            GetUserSuspensionFunction(userId);
            Console.WriteLine(email + " was suspended successfully");
        }
    }
}