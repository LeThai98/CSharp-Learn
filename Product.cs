namespace Samppham
{
    public partial class Product
    {
        public ManuFactory manu { get; set; }
        public class ManuFactory
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }
        
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string GetInfo(){
            return $"Name: {Name}, Price: {Price}";
        }
    }
}