using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var stack=new Stack<int>();

            for (int i = 0; i < number; i++)
            {
                int[] operation = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


                if (operation[0] == 1)
                {
                    int numberToPush = operation[1];

                    stack.Push(numberToPush);
                }
                else if (operation[0] == 2)
                {

                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
                else if (operation[0] == 3)
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    
                }
                else if (operation[0] == 4)
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(String.Join(", ",stack));
        }
    }
}
