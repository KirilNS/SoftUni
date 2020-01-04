using System;

namespace P01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            long sum = firstNum + secondNum;
            long divide = sum / thirdNum;
            long multiply = divide * fourthNum;

            Console.WriteLine(multiply);
        }
    }
}
