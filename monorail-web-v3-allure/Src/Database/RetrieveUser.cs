using System;
using System.Data.SqlClient;

namespace monorail_web_v3.Database
{
    public static class RetrieveUser
    {
        public static string GetUserAfterQ2SpendOnboardingWithoutCard(string email)
        {
            string user = null;
            try
            {
                var sqlConnection = new SqlConnection(new DatabaseConfig().Builder.ConnectionString);
                sqlConnection.Open();

                var query = "select top 1 email from Users where Users.lastName='Test' and Users.email LIKE \'" +
                            email + "\'";

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
    }
}