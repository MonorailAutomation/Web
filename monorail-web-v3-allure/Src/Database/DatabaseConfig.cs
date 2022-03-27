using System.Data.SqlClient;

namespace monorail_web_v3.Database
{
    public static class DatabaseConfig
    {
        private const string DataSource = "vimvest-sqlserver-test.database.windows.net";
        private const string UserId = "DbLoginTest";
        private const string Password = "Heiwp&3&dji_8sIKd";
        private const string InitialCatalog = "Monarch-Db-";

        public static SqlConnectionStringBuilder Builder(string env)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = DataSource,
                UserID = UserId,
                Password = Password,
                InitialCatalog = InitialCatalog + CapitalizeFirstLetter(env)
            };
            return sqlConnectionStringBuilder;
        }

        private static string CapitalizeFirstLetter(string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
    }
}