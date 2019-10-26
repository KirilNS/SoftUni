using P01.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07.AllMinionsNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> minionNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string minionNamesQuery = "SELECT Name FROM Minions";

                using (SqlCommand command=new SqlCommand(minionNamesQuery,connection))
                {
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minionNames.Add((string)reader[0]);
                        }
                    }
                }
            }

            for (int i = 0; i < minionNames.Count/2; i++)
            {
                Console.WriteLine(minionNames[i]);
                Console.WriteLine(minionNames[minionNames.Count-1-i]);
            }

            if (minionNames.Count % 2 != 0)
            {
                Console.WriteLine(minionNames[minionNames.Count/2]);
            }
        }
    }
}
