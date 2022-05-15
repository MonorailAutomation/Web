using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using monorail_web_v3.Model.ConfigurationModel;
using monorail_web_v3.Test;

namespace monorail_web_v3.Database
{
    public static class DatabaseConfig
    {
        public static SqlConnectionStringBuilder Builder(string env)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = GetDatabaseConfiguration().DataSource,
                UserID = GetDatabaseConfiguration().UserId,
                Password = GetDatabaseConfiguration().Password,
                InitialCatalog = GetDatabaseConfiguration().InitialCatalogPrefix + CapitalizeFirstLetter(env)
            };
            return sqlConnectionStringBuilder;
        }

        private static DatabaseConfiguration GetDatabaseConfiguration()
        {
            var configuration = new ConfigurationBuilder().BuildAppSettings();

            var databaseConfiguration = configuration.GetSection("DatabaseConfiguration").Get<DatabaseConfiguration>();

            return databaseConfiguration;
        }

        private static string CapitalizeFirstLetter(string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
    }
}