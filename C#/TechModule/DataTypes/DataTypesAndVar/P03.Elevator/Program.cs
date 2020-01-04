using System;

namespace P03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int personsCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());


            int courses = (int)Math.Ceiling(personsCount / (double)elevatorCapacity);

            Console.WriteLine(courses);
        }
    }
}
