using System;

namespace P01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int biggestNum = 0;
            int secondNum = 0;
            int lastNum = 0;

            if (num1 >= num2 && num1>=num3)
            {
                biggestNum = num1;
                if (num2 >= num3)
                {
                    secondNum = num2;
                    lastNum = num3;
                }
                else
                {
                    secondNum = num3;
                    lastNum = num2;
                }
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                biggestNum = num2;
                if (num1 >= num3)
                {
                    secondNum = num1;
                    lastNum = num3;
                }
                else
                {
                    secondNum = num3;
                    lastNum = num1;
                }
            }
            else if (num3 >= num1 && num3 >= num2)
            {
                biggestNum = num3;
                if (num1 >= num2)
                {
                    secondNum = num1;
                    lastNum = num2;
                }
                else
                {
                    secondNum = num2;
                    lastNum = num1;
                }
            }

            Console.WriteLine(biggestNum);
            Console.WriteLine(secondNum);
            Console.WriteLine(lastNum);
        }
    }
}
