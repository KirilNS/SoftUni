using System;
using System.Linq;
using System.Collections.Generic;


namespace P05.FashionBotique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxWithClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int input = int.Parse(Console.ReadLine());

            Stack<int> clothes=new Stack<int>(boxWithClothes);

            int capacity = input;
            int boxCount = 1;

            while (clothes.Count!=0)
            {
                
                int cloth=clothes.Peek();

                if (capacity >= cloth)
                {
                    clothes.Pop();
                    capacity -= cloth;
                }
                else
                {
                    capacity = input;
                    boxCount++;
                }
            }

            Console.WriteLine(boxCount);


        }
    }
}
