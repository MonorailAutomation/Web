using System.Data.SqlClient;

namespace monorail_web_v3.Database
{
    public class DatabaseConfig
    {
        public SqlConnectionStringBuilder Builder { get; } = new SqlConnectionStringBuilder
        {
            DataSource = "vimvest-sqlserver-test.database.windows.net",
            UserID = "DbLoginTest",
            Password = "Heiwp&3&dji_8sIKd",
            InitialCatalog = "Monarch-Db-Dev"
        };
    }
}