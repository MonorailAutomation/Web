using System;
using System.Data.SqlClient;

namespace monorail_web_v3.Database
{
    public static class DestroyUser
    {
        public static void ChangeLastName(string email)
        {
            try
            {
                var sqlConnection = new SqlConnection(new DatabaseConfig().Builder.ConnectionString);
                sqlConnection.Open();

                var query = "update Users set Users.lastName='Used' where Users.Email=\'" + email + "\'";

                var command = new SqlCommand(query, sqlConnection).ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}