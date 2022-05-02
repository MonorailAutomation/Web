using System;
using static monorail_web_v3.Database.RetrieveUser;
using static monorail_web_v3.RestRequests.CloseMonorailAccount;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class UserManagementHelperFunctions
    {
        public static void DeleteUser(string email)
        {
            var userId = GetUserId(email);
            PostMonorailCloseUserId(userId);
            Console.WriteLine(email + " was deleted successfully");
        }
    }
}