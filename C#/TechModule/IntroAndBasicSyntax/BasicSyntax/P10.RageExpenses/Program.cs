using System;

namespace P10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGameCount = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            decimal totalPrice = (lostGameCount / 2 * headsetPrice) + (lostGameCount / 3 * mousePrice) +
                                 (lostGameCount / 6 * keyboardPrice)
                                 + (lostGameCount / 12 * displayPrice);

            Console.WriteLine($"Rage expenses: {totalPrice:F2} lv.");
        }
    }
}
