using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = n[0];
            int cols = n[1];

            char[,] matrix=new char[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    bool IsEquals = matrix[row, col] == matrix[row, col + 1]&& matrix[row, col] == matrix[row + 1, col]&&
                                    matrix[row, col] == matrix[row + 1, col + 1];

                    if (IsEquals)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
