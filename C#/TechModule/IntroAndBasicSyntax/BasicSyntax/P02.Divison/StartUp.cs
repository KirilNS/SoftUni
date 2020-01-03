using System;

namespace P02.Divison
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var divider = 0;

            if (number % 2 == 0)
            {
                divider = 2;
            }
            if (number % 3 == 0)
            {
                divider = 3;
            }
            if (number % 3 == 0 && number % 2 == 0)
            {
                divider = 6;
            }
            if (number % 7 == 0 )
            {
                divider = 7;
            }
            if (number % 10 == 0 )
            {
                divider = 10;
            }

            Console.WriteLine(divider != 0 ? $"The number is divisible by {divider}" : "Not divisible");
        }
    }
}
