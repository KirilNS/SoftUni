using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double sum = 0.0;

            switch (typeOfPeople)
            {
                case "Students" when numberPeople >= 30:
                {
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            sum = (numberPeople * 8.45) * 0.85;
                            break;
                        case "Saturday":
                            sum = (numberPeople * 9.8) * 0.85;
                            break;
                        case "Sunday":
                            sum = (numberPeople * 10.46) * 0.85;
                            break;
                    }

                    break;
                }
                case "Students" when numberPeople < 30:
                {
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            sum = (numberPeople * 8.45);
                            break;
                        case "Saturday":
                            sum = (numberPeople * 9.8);
                            break;
                        case "Sunday":
                            sum = (numberPeople * 10.46);
                            break;
                    }

                    break;
                }
                case "Business" when numberPeople >= 100:
                {
                    numberPeople -= 10;
                    if (dayOfWeek == "Friday")
                    {
                        sum = numberPeople * 10.9;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        sum = numberPeople * 15.6;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        sum = numberPeople * 16.0;
                    }

                    break;
                }
                case "Business" when dayOfWeek == "Friday":
                    sum = numberPeople * 10.9;
                    break;
                case "Business" when dayOfWeek == "Saturday":
                    sum = numberPeople * 15.6;
                    break;
                case "Business":
                {
                    if (dayOfWeek == "Sunday")
                    {
                        sum = numberPeople * 16.0;
                    }

                    break;
                }
                case "Regular" when numberPeople >= 10 && numberPeople <= 20:
                {
                    if (dayOfWeek == "Friday")
                    {
                        sum = (numberPeople * 15.0) * 0.95;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        sum = (numberPeople * 20.0) * 0.95;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        sum = (numberPeople * 22.5) * 0.95;
                    }

                    break;
                }
                case "Regular" when dayOfWeek == "Friday":
                    sum = (numberPeople * 15.0);
                    break;
                case "Regular" when dayOfWeek == "Saturday":
                    sum = (numberPeople * 20.0);
                    break;
                case "Regular":
                {
                    if (dayOfWeek == "Sunday")
                    {
                        sum = (numberPeople * 22.5);
                    }

                    break;
                }
            }

            Console.WriteLine($"Total price: {sum:F2}");
        }
    }
}
