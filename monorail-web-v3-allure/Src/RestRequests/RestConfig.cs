using System;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;


namespace monorail_web_v3.RestRequests
{
    public class RestConfig
    {
        public static readonly Uri MonorailUri = new Uri(MonorailUrl);
    }
}