using static monorail_web_v3.RestRequests.Endpoints.Monarch.Token;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.V3.Goals;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class PortfolioHelperFunctions
    {
        public static void RevertPortfolio(string username, string portfolioId,
            string portfolioName, string portfolioDescription)
        {
            var token = GenerateToken(username);
            PatchGoals(token, portfolioId, portfolioDescription, portfolioName);
            //PutGoals(token, portfolioId, portfolioTargetAmount, portfolioTargetDate);
        }
    }
}