using System;

namespace P09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            decimal lightsaberPrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());


            int lightsabers = (int) Math.Ceiling(countStudents * 1.10m);
            int robes = countStudents;
            int belts = countStudents - (countStudents / 6);

            decimal totalPrice = (lightsaberPrice * lightsabers) + (robePrice * robes) + (belts * beltPrice);

            if (amountOfMoney >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice-amountOfMoney:F2}lv more.");
            }
        }
    }
}
