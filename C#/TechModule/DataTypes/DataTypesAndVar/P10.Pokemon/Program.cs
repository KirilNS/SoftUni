using System;

namespace P10.Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            double half = n / 2.0;
            int count = 0;

            while (n >= m && n != 0)
            {

                n -= m;
                count++;

                if (n == half)
                {
                    if (y != 0)
                    {
                        n /= y;
                    }
                    
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(count);
        }
    }
}
