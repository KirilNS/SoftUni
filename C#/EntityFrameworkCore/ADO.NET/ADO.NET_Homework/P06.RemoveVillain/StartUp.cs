using P01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace P06.RemoveVillain
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection=new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
                string villainName;

                using (SqlCommand command=new SqlCommand(villainNameQuery,connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                     villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                int releasedMinions=DeleteMinions(connection, villainId);
                DeleteVillain(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }

        private static void DeleteVillain(SqlConnection connection, int villainId)
        {
            string villainQuery = @"DELETE FROM Villains
                                    WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(villainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                command.ExecuteNonQuery();

            }
        }

        private static int DeleteMinions(SqlConnection connection, int villainId)
        {
            string minionsQuery = @"DELETE FROM MinionsVillains 
                                    WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(minionsQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return command.ExecuteNonQuery();
                
            }
        }
    }
}
