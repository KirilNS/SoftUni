using System;
using System.Data.SqlClient;

namespace P01.InitialSetup
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string connectionString = Configuration.connectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                string cmdText = "CREATE DATABASE MinionsDB";

                connection.Open();

                NonQuery(connection, cmdText);
            }
        }

        private static void NonQuery(SqlConnection connection, string cmdText)
        {
            using (SqlCommand command = new SqlCommand(cmdText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
