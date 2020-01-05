using System;
using System.Numerics;

namespace P11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            BigInteger biggestValue = 0;
            int bigSnowballSnow=0;
            int bigSnowballTime=0;
            int bigSnowballQuality = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (biggestValue <= value)
                {
                    biggestValue = value;
                    bigSnowballSnow = snowballSnow;
                    bigSnowballTime = snowballTime;
                    bigSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{bigSnowballSnow} : {bigSnowballTime} = {biggestValue} ({bigSnowballQuality})");
        }
    }
}
