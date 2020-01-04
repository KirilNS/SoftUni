using System;

namespace P05.PrintPartOfAscii
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            for (char i = (char)startIndex; i <= endIndex; i++)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();
        }
    }
}
