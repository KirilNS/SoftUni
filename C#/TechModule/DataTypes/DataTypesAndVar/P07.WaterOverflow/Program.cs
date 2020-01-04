using System;

namespace P07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int tankCapacity = 255;
            int liters = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int waterLiters = int.Parse(Console.ReadLine());

                if (tankCapacity - waterLiters >= 0)
                {
                    tankCapacity -= waterLiters;
                    liters += waterLiters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(liters);
        }
    }
}
