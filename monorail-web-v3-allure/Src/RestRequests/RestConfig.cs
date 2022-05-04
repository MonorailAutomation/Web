using System;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.RestRequests
{
    public static class RestConfig
    {
        public static readonly Uri MonorailAppUri = new Uri("https://monarch-app-" + MonorailEnv + ".azurewebsites.net");

        public static readonly Uri MonarchManagementUri =
            new Uri("https://monarchmanagement-app-" + MonorailEnv + ".azurewebsites.net");

        public static readonly Uri AzureFunctionsUri =
            new Uri("https://monarch-functionsapp-" + MonorailEnv + ".azurewebsites.net");
    }
}