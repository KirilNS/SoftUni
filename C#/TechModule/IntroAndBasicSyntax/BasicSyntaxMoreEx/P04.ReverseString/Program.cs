using System;

namespace P04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output=String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                output += input[input.Length - 1 - i];
            }

            Console.WriteLine(output);
        }
    }
}
