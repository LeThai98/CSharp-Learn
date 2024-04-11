using System;
using static System.Math;


using X = MyNameSpace;

namespace MyApp
{
    internal class Program  
    {
        static void Main(string[] args)
        {
           Action<string> logGreen = null;
           Action<string> logRed = null;

           logGreen += ShowGreenLog;
           logRed += ShowRedLog;

           CalSum(1, 2, logGreen, logRed);
            CalSum(1, -2, logGreen, logRed);

        }

        public static void CalSum(int a, int b, Action<string> logGreen, Action<string> logRed)
        {
            if(a + b >= 0)
                logGreen?.Invoke($"Sum: {a + b}");
            else
                 logRed?.Invoke($"Sum: {a + b}");
        }
        
        public static void ShowGreenLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowRedLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}