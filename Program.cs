using static System.Console;
using static System.Math;


using X = MyNameSpace;

namespace MyApp
{
    internal class Program  
    {
        static async Task Main(string[] args)
        {
            var r1 = RunTask1();
            var r2 =  RunTask2();
            // await r1;
            // await r2;
            Task.WaitAll(r1, r2);

            var result1 = r1.Result;
            Console.WriteLine($"The program already {result1}");
            var result2 = r2.Result;
            Console.WriteLine($"The program already {result2}");

            DoSomeThing("Main Thread", 2, ConsoleColor.White);
            Console.WriteLine("Main Thread completed");

        }

        public static void DoSomeThing(string message, int seconds, ConsoleColor color){
            for (int i = 1; i <= seconds; i++)
            {
                lock(Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{message} : {i}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);
            }
        }

        public static async Task<string> RunTask1(){
            Task<string> t1 = new Task<string>(() => {
                DoSomeThing("T1", 3, ConsoleColor.DarkGreen);
                return "completed T1";
            });
            t1.Start();
            var result =  await t1;
            Console.WriteLine($"{result}");
            return result;
        }

        public static async Task<string> RunTask2(){
            Task<string> t2 = new Task<string>(() => {
                DoSomeThing("T2", 10, ConsoleColor.Red);
                return "completed T2";
            });
            t2.Start();
            var result =  await t2;
            Console.WriteLine($"{result}");
            return result;
        }
    }
}