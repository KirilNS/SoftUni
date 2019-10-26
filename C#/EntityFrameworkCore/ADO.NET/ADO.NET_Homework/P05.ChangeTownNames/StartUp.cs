using P01.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05.ChangeTownNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string updateTownNamesQuery = @"UPDATE Towns
                   SET Name = UPPER(Name)
                 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                int rowsAffected = 0;

                using (SqlCommand command=new SqlCommand(updateTownNamesQuery,connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    rowsAffected = command.ExecuteNonQuery();

                }

                if (rowsAffected > 0)
                {
                    string selectTownsNames = @"SELECT t.Name 
                      FROM Towns as t
                      JOIN Countries AS c ON c.Id = t.CountryCode
                     WHERE c.Name = @countryName";

                    List<string> townsNames = new List<string>();

                    using (SqlCommand command=new SqlCommand(selectTownsNames,connection))
                    {
                        command.Parameters.AddWithValue("@countryName", country);

                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                townsNames.Add((string)reader[0]);
                            }
                        }
                    }

                    Console.WriteLine($"{rowsAffected} town names were affected.");
                    Console.WriteLine("["+string.Join(", ",townsNames)+"]");
                }

                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
