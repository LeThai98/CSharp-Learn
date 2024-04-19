using CSharp_Learn.Interfaces;
using CSharp_Learn.Services;
using Microsoft.Extensions.Configuration;
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

            IConfigurationRoot configurationRoot;
            ConfigurationBuilder configureBuilder = new ConfigurationBuilder();

            //configureBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configureBuilder.SetBasePath("D:\\Project\\Back-End\\CShap_Proj\\CSharp-Learn");

            configureBuilder.AddJsonFile("cauhinh.json");

            configurationRoot = configureBuilder.Build();
            var key1 =configurationRoot.GetSection("section1").GetSection("Name").Value;
            var key2 = configurationRoot.GetSection("section1").GetSection("Age").Value;

            Console.WriteLine(key1); Console.WriteLine(key2);


            /// use Configuration with Option in DI

            var myOptionConfigurations = configurationRoot.GetSection("section1");
            var services = new ServiceCollection();


            // inject Configuration Options for Services
            services.Configure<MyServiceOption>(myOptionConfigurations);

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

        public MyService(IOptions<MyServiceOption> options) 
        {
            Name = options.Value.Name;
            Age = options.Value.Age;
            Op1 = options.Value.Op1;
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