using System;

namespace P07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            decimal totalSum = 0.0m;

            while (input.ToLower()!="start")
            {
                decimal coins = decimal.Parse(input);

                bool validCoins = coins == 0.1m || coins == 0.2m || coins == 0.5m || coins == 1.0m || coins == 2.0m;

                if (!validCoins)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    
                }
                else
                {
                    totalSum += coins;
                }

                input = Console.ReadLine();
            }

            string purchase = Console.ReadLine();

            while (purchase.ToLower()!="end")
            {
                if (purchase == "Nuts")
                {
                    if (totalSum >= 2.0m)
                    {
                        totalSum -= 2.0m;
                        Console.WriteLine($"Purchased {purchase.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (purchase == "Water")
                {
                    if (totalSum >= 0.7m)
                    {
                        totalSum -= 0.7m;
                        Console.WriteLine($"Purchased {purchase.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (purchase == "Crisps")
                {
                    if (totalSum >= 1.5m)
                    {
                        totalSum -= 1.5m;
                        Console.WriteLine($"Purchased {purchase.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (purchase == "Soda")
                {
                    if (totalSum >= 0.8m)
                    {
                        totalSum -= 0.8m;
                        Console.WriteLine($"Purchased {purchase.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (purchase == "Coke")
                {
                    if (totalSum >= 1.0m)
                    {
                        totalSum -= 1.0m;
                        Console.WriteLine($"Purchased {purchase.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                purchase = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totalSum:F2}");
        }
    }
}
