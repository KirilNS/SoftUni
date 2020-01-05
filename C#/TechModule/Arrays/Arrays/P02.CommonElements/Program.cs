using System;

namespace P02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] secondArray = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            foreach (var VARIABLE in secondArray)
            {
                foreach (var item in firstArray)
                {
                    if (item == VARIABLE)
                    {
                        Console.Write(item+" ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
