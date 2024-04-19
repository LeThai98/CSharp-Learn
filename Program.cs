using CSharp_Learn.Interfaces;
using CSharp_Learn.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static System.Console;
using static System.Math;
using X = MyNameSpace;

namespace MyApp
{
    internal class Program  
    {
        
        static void Main(string[] args)
        {
            

            var services = new ServiceCollection();

            // inject Options for Services
            services.Configure<MyServiceOption>(
                (options) =>
                {
                    options.Name = "Thai";
                    options.Age = 26;
                    options.Op1 = 1;
                    options.Op2 = 2;
                    options.Op3 = 3;
                    options.Op4 = 4;
                    options.Op5 = 5;
                    options.Op6 = 6;
                    options.Op7 = 7;
                    options.Op8 = 8;
                    options.Op9 = 9;
                    options.Op10 = 10;
                }
           );

            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();

            var myService = provider.GetService<MyService>();
            myService.WriteMessage();
            
        }
    }

    internal class MyServiceOption
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Op1 { get; set; }
        public int Op2 { get; set; }
        public int Op3 { get; set; }
        public int Op4 { get; set; }
        public int Op5 { get; set; }
        public int Op6 { get; set; }
        public int Op7 { get; set; }
        public int Op8 { get; set; }
        public int Op9 { get; set; }
        public int Op10 { get; set; }


    }
    internal class MyService
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Op1 { get; set; }
        public int Op2 { get; set; }
        public int Op3 { get; set; }

        public MyService(IOptions<MyServiceOption> options) 
        {
            Name = options.Value.Name;
            Age = options.Value.Age;
            Op1 = options.Value.Op1;
            Op2 = options.Value.Op2;
            Op3 = options.Value.Op3;
        }

        public void WriteMessage()
        {
            Console.WriteLine($" {Name}  -- Age:{Age} -- option:{Op1}");
        }
    }

    internal class Breakfast
    {
        private IBreaf breaf;

        public Breakfast(IBreaf _breaf)
        {
            breaf = _breaf;
        }

        public void Eat()
        {
            breaf.NuongBreak();
            Console.WriteLine("Yummy");
        }
    }

    public interface IBreaf
    {
        void NuongBreak();
    }

    internal class Breaf1: IBreaf
    {
        private string bot;

        //public Breaf(string _bot)
        //{
        //    this.bot = _bot;
        //}

        public void NuongBreak()
        {
            Console.WriteLine("Nuong Xeo Xeo");
        }
    }

    internal class Breaf2 : IBreaf
    {
        private string bot;

        //public Breaf(string _bot)
        //{
        //    this.bot = _bot;
        //}

        public void NuongBreak()
        {
            Console.WriteLine("Nuong Thom Phuc");
        }
    }


}