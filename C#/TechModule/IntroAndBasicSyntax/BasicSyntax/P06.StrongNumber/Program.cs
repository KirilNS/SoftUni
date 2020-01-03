using System;

namespace P06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            var strongNumber = input;
            int sum = 0;

            while (input != 0)
            {
                var lastNumber = input % 10;
                input = input / 10;

                var number = 1;

                for (int i = 1; i <= lastNumber; i++)
                {
                    number *= i;
                }

                sum += number;
            }

            if (sum == strongNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
