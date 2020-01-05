using System;
using System.Linq;

namespace P02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                long[] numbers = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long leftNumber = numbers[0];
                long rightNumber = numbers[1];
                long sum = 0;

                if (leftNumber >= rightNumber)
                {
                    while (leftNumber!=0)
                    {
                        sum += leftNumber % 10;
                        leftNumber /= 10;
                    }
                }
                else
                {
                    while (rightNumber != 0)
                    {
                        sum += rightNumber % 10;
                        rightNumber /= 10;
                    }
                }

                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}
