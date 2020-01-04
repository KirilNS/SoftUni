using System;

namespace P08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg=String.Empty;
            double biggestVolume = 0.0;

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var radius = double.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (biggestVolume < volume)
                {
                    biggestVolume = volume;
                    biggestKeg = name;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
