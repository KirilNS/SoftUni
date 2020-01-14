using System;
using System.Linq;

namespace P03.MaximalSum
{
    class Program
    {
        private const int matrixSquareSide = 3;
        static void Main(string[] args)
        {
            int[] matrixSides = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = matrixSides[0];
            int cols = matrixSides[1];

            int[,] matrix=new int[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                int[] input= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = -1;
            int colIndex = -1;

            for (int row = 0; row < matrix.GetLength(0)-matrixSquareSide+1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-matrixSquareSide+1; col++)
                {
                    int sum = 0;

                    for (int i = row; i <row+ matrixSquareSide; i++)
                    {
                        for (int j = col; j < col+matrixSquareSide; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowIndex; row < matrixSquareSide+rowIndex; row++)
            {
                for (int col = colIndex; col < matrixSquareSide+colIndex; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
