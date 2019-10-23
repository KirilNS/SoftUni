using P01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace P03.MinionName
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            using (SqlConnection connection=new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string villainNameQuery = $"SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command=new SqlCommand(villainNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id",input);
                    string villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {input} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                string villainMinions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command=new SqlCommand(villainMinions,connection))
                {
                    command.Parameters.AddWithValue("@Id", input);
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long row = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];

                            Console.WriteLine($"{row}. {name} {age}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}
