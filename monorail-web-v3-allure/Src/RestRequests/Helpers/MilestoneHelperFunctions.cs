using static monorail_web_v3.RestRequests.Endpoints.Monarch.Token;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.Goals;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class MilestoneHelperFunctions
    {
        public static void RevertMilestone(string username, string milestoneId,
            string milestoneName, string milestoneDescription)
        {
            var token = GenerateToken(username);
            PatchGoals(token, milestoneId, milestoneDescription, milestoneName);
            //PutGoals(token, milestoneId, milestoneTargetAmount, milestoneTargetDate);
        }
    }
}