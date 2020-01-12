using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] input=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orders=new Queue<int>(input);

            int biggestOrder = orders.Max();

            while (orders.Count!=0)
            {
                int order = orders.Peek();

                bool isBigger = quantity - order >= 0;

                if (!isBigger)
                {
                    break;
                }

                order = orders.Dequeue();
                quantity -= order;
            }

            Console.WriteLine(biggestOrder);

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }


        }
    }
}
