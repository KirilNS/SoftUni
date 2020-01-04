using System;

namespace P03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentBalance = decimal.Parse(Console.ReadLine());

            var totalSpend = 0.0m;

            string command=String.Empty;

            while ((command=Console.ReadLine())!="Game Time")
            {
                if (command == "OutFall 4")
                {
                    if (currentBalance - 39.99m >= 0)
                    {
                        Console.WriteLine($"Bought {command}”");
                        totalSpend += 39.99m;
                        currentBalance -= 39.99m;

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "CS: OG")
                {
                    if (currentBalance - 15.99m >= 0)
                    {
                        Console.WriteLine($"Bought {command}”");
                        totalSpend += 15.99m;
                        currentBalance -= 15.99m;

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (currentBalance - 19.99m >= 0)
                    {
                        Console.WriteLine($"Bought {command}”");
                        totalSpend += 19.99m;
                        currentBalance -= 19.99m;

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Honored 2")
                {
                    if (currentBalance - 59.99m >= 0)
                    {
                        Console.WriteLine($"Bought {command}”");
                        totalSpend += 59.99m;
                        currentBalance -= 59.99m;

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (currentBalance - 29.99m >= 0)
                    {
                        Console.WriteLine($"Bought {command}”");
                        totalSpend += 29.99m;
                        currentBalance -= 29.99m;

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (currentBalance - 39.99m >= 0)
                    {
                        Console.WriteLine($"Bought {command}”");
                        totalSpend += 39.99m;
                        currentBalance -= 39.99m;

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }

            Console.WriteLine($"Total spent: ${totalSpend:F2}. Remaining: ${currentBalance:F2}");
        }
    }
}
