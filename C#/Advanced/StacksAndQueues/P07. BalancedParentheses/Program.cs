using System;
using System.Collections.Generic;

namespace P07._BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> leftChars = new Stack<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    leftChars.Push(input[i]);
                }
                else if (input[i] == '[')
                {
                    leftChars.Push(input[i]);
                }
                else if (input[i] == '{')
                {
                    leftChars.Push(input[i]);
                }
                else
                {
                    char rightChar = input[i];
                    bool isValid = false;
                    if (leftChars.Peek() == '(' && rightChar == ')')
                    {
                        leftChars.Pop();
                        isValid = true;
                    }
                    else if (leftChars.Peek() == '[' && rightChar == ']')
                    {
                        leftChars.Pop();
                        isValid = true;
                    }
                    else if (leftChars.Peek() == '{' && rightChar == '}')
                    {
                        leftChars.Pop();
                        isValid = true;
                    }

                    if (!isValid)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}

