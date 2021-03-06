using System;
using Microsoft.Extensions.Configuration;
using monorail_web_v3.Model.ConfigurationModel;
using monorail_web_v3.Test;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.RestRequests
{
    public static class RestConfig
    {
        public static readonly Uri MonarchAppUri =
            new Uri("https://monarch-app-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri MonarchManagementUri =
            new Uri("https://monarchmanagement-app-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri AzureFunctionsUri =
            new Uri("https://monarch-functionsapp-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri PlaidUri = new Uri("https://sandbox.plaid.com");

        public static EndpointConfiguration GetEndpointConfiguration()
        {
            var configuration = new ConfigurationBuilder().BuildAppSettings();

            var endpointConfiguration = configuration.GetSection("EndpointConfiguration").Get<EndpointConfiguration>();

            return endpointConfiguration;
        }
    }
}