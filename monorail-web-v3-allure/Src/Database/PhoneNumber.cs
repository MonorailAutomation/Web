using System;
using System.Data.SqlClient;

namespace monorail_web_v3.Database
{
    public static class PhoneNumber
    {
        public static bool CheckIfPhoneNumberWasUsedOnUatAndDev(string phoneNumber)
        {
            var phoneUsageOnDev = CheckPhoneNumberUsage(phoneNumber, "Dev");
            var phoneUsageOnUat = CheckPhoneNumberUsage(phoneNumber, "Uat");

            return phoneUsageOnDev != false || phoneUsageOnUat != false;
        }

        private static bool? CheckPhoneNumberUsage(string phoneNumber, string env)
        {
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(env).ConnectionString);
                sqlConnection.Open();

                var query = "select count(*) from users where phoneNumber = \'" + phoneNumber + "\'";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();

                var numberUsages = 0;
                while (reader.Read()) numberUsages = reader.GetInt32(0);

                Console.WriteLine(env + " usages: " + numberUsages);

                return numberUsages != 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }
    }
}