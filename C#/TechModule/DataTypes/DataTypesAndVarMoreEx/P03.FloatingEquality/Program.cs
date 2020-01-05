using System;

namespace P03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            var diff = 0.000001;

            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Abs(firstNumber - secondNumber) > diff ? "False" : "True");
        }
    }
}
