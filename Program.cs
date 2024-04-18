using Microsoft.Extensions.DependencyInjection;
using static System.Console;
using static System.Math;
using X = MyNameSpace;

namespace MyApp
{
    internal class Program  
    {
        static void Main(string[] args)
        {
            //Breaf breaf = new Breaf();
            //Breakfast breakfast = new Breakfast(breaf);
            //breakfast.Eat();


            // initial DI Container
            IServiceCollection services = new ServiceCollection();

            // register services
            services.AddSingleton<IBreaf, Breaf1>();
            //services.AddSingleton<IBreaf, Breaf2>();
            services.AddSingleton<Breakfast>();

            // build Service Provider
            var provider = services.BuildServiceProvider();
            
            // get instance of service from Service Provider
            //var breaf = provider.GetService<IBreaf>();

            Breakfast breakfast = provider.GetService<Breakfast>();
            breakfast.Eat();




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