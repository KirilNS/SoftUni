using System;

namespace P01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input!="END")
            {
                int integer = 0;
                double doub = 0.0;
                string str=String.Empty;
                char ch = ' ';
                bool boolean = false;

                if (int.TryParse(input, out integer))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out doub))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out ch))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out boolean))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
