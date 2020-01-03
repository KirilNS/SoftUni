using System;
using System.Linq;

namespace P05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();

                string password=String.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    password+= input[input.Length-j-1];
                }

                if (password == username)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else if (i<3)
                {
                    Console.WriteLine($"Incorrect password. Try again.");
                }

                
            }

            Console.WriteLine($"User {username} blocked!");
        }
    }
}
