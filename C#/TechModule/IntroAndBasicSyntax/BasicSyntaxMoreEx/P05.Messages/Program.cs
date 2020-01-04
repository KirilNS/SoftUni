using System;

namespace P05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string word=String.Empty;

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int num = number;
                int numberOfDigits = 0;
                int mainDigit = 0;

                while (num != 0)
                {
                    num /= 10;
                    numberOfDigits++;
                }

                switch (number%10)
                {
                    case 0: mainDigit = 0;break;
                    case 2: mainDigit = 2;break;
                    case 3: mainDigit = 3;break;
                    case 4: mainDigit = 4;break;
                    case 5: mainDigit = 5;break;
                    case 6: mainDigit = 6;break;
                    case 7: mainDigit = 7;break;
                    case 8: mainDigit = 8;break;
                    case 9: mainDigit = 9;break;
                    
                }

                if (mainDigit != 0)
                {
                    int offset = (mainDigit - 2) * 3;

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset += 1;
                    }

                    int letterIndex = (offset + numberOfDigits - 1);

                    char letter = (char)(97 + letterIndex);

                    word += letter;
                }
                else
                {
                    word += " ";
                }
                

                
            }

            Console.WriteLine(word);
        }
    }
}
