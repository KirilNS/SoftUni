using P01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace P09.StoredProcedureIncreaseAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string query = "EXEC dbo.usp_GetOlder @id";

                using (SqlCommand command=new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }

                string selectQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand command= new SqlCommand(selectQuery,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];
                            Console.WriteLine($"{name} – {age} years old");
                        }
                    }

                }
            }
        }
    }
}
