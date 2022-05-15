using System;
using System.Data.SqlClient;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.Database
{
    public static class WishlistItem
    {
        public static void ClearWishlistItem(string wishlistItemId)
        {
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(MonorailTestEnvironment).ConnectionString);
                sqlConnection.Open();

                var query =
                    "update WishlistItems set name = NULL, description = NULL, amount = NULL, imageURL = NULL where id=\'" +
                    wishlistItemId + "\'";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}