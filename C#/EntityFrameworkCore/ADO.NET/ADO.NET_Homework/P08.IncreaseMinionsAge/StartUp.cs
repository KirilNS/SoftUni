using P01.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace P08.IncreaseMinionsAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string query = @"UPDATE Minions
                                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                 WHERE Id = @Id";
                UpdateMinions(minionsId, connection, query);

                string selectMinionsQuery = @"SELECT Name, Age FROM Minions";

                

                using (SqlCommand command = new SqlCommand(selectMinionsQuery, connection))
                {
                    List<string> minionsInfo = new List<string>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} {age}");

                        }

                    }
                    
                }
            }
        }

       
        private static void UpdateMinions(int[] minionsId, SqlConnection connection, string query)
        {
            for (int i = 0; i < minionsId.Length; i++)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    command.Parameters.AddWithValue("@Id", minionsId[i]);
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
