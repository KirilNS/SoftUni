﻿using System;

namespace P01.Ages
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            string person = String.Empty;

            if (age <= 2)
            {
                person = "baby";
            }
            else if (age <= 13)
            {
                person = "child";
            }
            else if (age <= 19)
            {
                person = "teenager";
            }
            else if (age <= 65)
            {
                person = "adult";
            }
            else
            {
                person = "elder";
            }

            Console.WriteLine(person);
        }
    }
}
