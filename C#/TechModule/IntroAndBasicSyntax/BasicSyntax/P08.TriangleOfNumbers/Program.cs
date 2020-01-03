using System;

namespace P08.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < row+1; col++)
                {
                    Console.Write(row+1+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
