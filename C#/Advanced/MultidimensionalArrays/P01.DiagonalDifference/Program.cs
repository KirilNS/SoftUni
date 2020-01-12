using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix=new int[n,n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int leftDiagonal = 0;
            int rightDiagonal = 0;

            int count = matrix.GetLength(0);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                leftDiagonal += matrix[row, row];
                rightDiagonal += matrix[row, --count];
            }

            Console.WriteLine(Math.Abs(leftDiagonal-rightDiagonal));
        }
    }
}
