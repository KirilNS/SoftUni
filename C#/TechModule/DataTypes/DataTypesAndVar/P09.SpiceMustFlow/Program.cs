using System;

namespace P09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int spice = int.Parse(Console.ReadLine());

            int totalSpice = 0;
            int days = 0;

            while (spice>=100)
            {
                days++;
                totalSpice += spice-26;
                spice -= 10;
                
            }

            totalSpice -= 26;
            if (totalSpice < 0)
            {
                totalSpice = 0;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
