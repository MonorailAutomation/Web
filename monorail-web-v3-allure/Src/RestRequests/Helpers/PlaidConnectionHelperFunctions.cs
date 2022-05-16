using System;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.MoneyAch;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.Token;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.VerifyStatus;
using static monorail_web_v3.RestRequests.Endpoints.Plaid.LinkItemCreate;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class PlaidConnectionHelperFunctions
    {
        public static void VerifyPlaidConnection(string username)
        {
            var token = GenerateToken(username);
            var verifyStatus = GetVerifyStatus(token);
            if (verifyStatus.Equals("OK")) return;

            Console.WriteLine("Reconnecting Plaid account");
            var plaidData = PostLinkItemCreate(username);
            PostMoneyAch(token, plaidData[0], plaidData[1]);
        }
    }
}