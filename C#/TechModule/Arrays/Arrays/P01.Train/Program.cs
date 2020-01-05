using System;

namespace P01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] wagonsCapacity=new int[wagons];

            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());

                wagonsCapacity[i] = numberOfPeople;
                sum += numberOfPeople;
            }

            Console.WriteLine(string.Join(" ",wagonsCapacity));
            Console.WriteLine(sum);
        }
    }
}
