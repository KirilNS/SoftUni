using System;

namespace P05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            int lines = int.Parse(Console.ReadLine());

            string message=String.Empty;

            for (int i = 0; i < lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                message += (char)(letter + key);
            }

            Console.WriteLine(message);
        }
    }
}
