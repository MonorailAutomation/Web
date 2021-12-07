using static monorail_web_v3.RestRequests.Token;
using static monorail_web_v3.RestRequests.Goals;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class MilestoneHelperFunctions
    {
        public static void RevertMilestone(string username, string password, string milestoneId,
            string milestoneName, string milestoneDescription)
        {
            var token = GenerateToken(username, password);
            PatchGoals(token, milestoneId, milestoneDescription, milestoneName);
            //PutGoals(token, milestoneId, milestoneTargetAmount, milestoneTargetDate);
        }
    }
}