using System;
using System.Data.SqlClient;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.Database
{
    public static class RetrieveUser
    {
        public static string GetUserAfterQ2SpendOnboardingWithoutCard(string email)
        {
            string user = null;
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(MonorailTestEnvironment).ConnectionString);
                sqlConnection.Open();

                var query = "select top 1 email from Users where Users.lastName='Test' and Users.email LIKE \'" +
                            email + "\' and Users.IsDeleted=0 and id in (select userid from spots where type ='Checking')";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();

                while (reader.Read()) user = reader.GetString(0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return user;
        }

        public static string GetUserId(string email)
        {
            Guid? userId = null;
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(MonorailTestEnvironment).ConnectionString);
                sqlConnection.Open();

                var query = "select top 1 id from Users where Users.email=\'" + email + "\'";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();

                while (reader.Read()) userId = reader.GetGuid(0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return userId.ToString();
        }
    }
}