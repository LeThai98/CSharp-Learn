using static System.Console;
using static System.Math;


using X = MyNameSpace;

namespace MyApp
{
    internal class Program  
    {
        static void Main(string[] args)
        {
           Samppham.Product product = new Samppham.Product("Laptop", 1000);
           product.description = "Fake Product";
              WriteLine(product.GetInfo());
                WriteLine(product.description);

            Samppham.Product.ManuFactory manu = new Samppham.Product.ManuFactory();
            manu.Name = "Samppham";
            manu.Address = "Vietnam";
            WriteLine(manu.Name);
        }
    }
}