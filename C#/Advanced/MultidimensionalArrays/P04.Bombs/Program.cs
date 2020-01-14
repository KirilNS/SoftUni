using System;
using System.Linq;

namespace P04.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string[] coordinates = Console.ReadLine()
                .Split(" ")
                .ToArray();

            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] bomb = coordinates[i].Split(',').ToArray();
                int bombRow = int.Parse(bomb[0]);
                int bombCol = int.Parse(bomb[1]);


                for (int row = bombRow - 1; row <= bombRow + 1; row++)
                {
                    for (int col = bombCol - 1; col <= bombCol + 1; col++)
                    {
                        if (IsValidCoordinate(row, col, matrix) && matrix[row, col] > 0 && IsNotBombCell(bombRow, bombCol, row, col))
                        {
                            matrix[row, col] -= matrix[bombRow, bombCol];
                        }
                    }
                }

                matrix[bombRow, bombCol] = 0;
            }

            int aliveCells = 0;
            int sumOfAliveCells = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumOfAliveCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsNotBombCell(int bombRow, int bombCol, int row, int col)
        {
            return bombRow != row || bombCol != col;
        }

        private static bool IsValidCoordinate(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
