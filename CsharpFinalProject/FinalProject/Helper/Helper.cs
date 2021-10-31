using System;
using System.Threading;

namespace FinalProjectCopy.Helper
{
    static class Helper
    {
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Loading(string LoadingWord)
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write(LoadingWord);
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(".");
                    Thread.Sleep(2000);
                }
            }
            Console.WriteLine(".");
        }
        public static int TryParse(string number, string error)
        {
            int parsenum;
        sp:
            bool check = int.TryParse(number, out parsenum);
            if (check == false)
            {
                Console.WriteLine(error);
                number = Console.ReadLine();
                goto sp;
            }

            if (parsenum < 0)
            {
                Console.WriteLine(error);
                number = Console.ReadLine();
                goto sp;
            }
            return parsenum;
        }
    }
}
