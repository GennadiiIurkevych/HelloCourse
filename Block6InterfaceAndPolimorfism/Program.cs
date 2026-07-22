using Block6InterfaceAndPolimorfism;
using System.Numerics;


namespace Block6InterfaceAndPolimorfism
{

    public interface IDiscountStrategy
    {
        abstract decimal ApplyDiscount(decimal originalPrice);
        string Description { get; }
    }

    // Якщо Блок 5 ще не зроблено — досить мати клас з Price (decimal) і Category (string)
    public sealed class ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string Category { get; init; } = "";
        public decimal Price { get; init; }
    }


    public class Program
    {
        public sealed class NoDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal originalPrice)
            {
                return originalPrice;
            }
            public string Description => "No discount";
        }


        public sealed class PercentageDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal originalPrice)
            {
                var percent = 15m;
                return originalPrice - (originalPrice / 100 * percent);
            }
            public string Description => "15% off";
        }

        public sealed class FixedAmountDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal originalPrice)
            {
                var amount = 10m;
                return originalPrice - amount;
            }
            public string Description => "$10 off";
        }

        static void Main(string[] args)
        {
            var noDiscount = new NoDiscount();

            Console.WriteLine($"{noDiscount.ApplyDiscount(200m)} - {noDiscount.Description}");
            Console.WriteLine("______________________");

            var percentageDiscount = new PercentageDiscount();

            Console.WriteLine($"{percentageDiscount.ApplyDiscount(100m)} - {percentageDiscount.Description}");
            Console.WriteLine("______________________");

            var fixedAmountDiscount = new FixedAmountDiscount();

            Console.WriteLine($"{fixedAmountDiscount.ApplyDiscount(60m)} - {fixedAmountDiscount.Description}");

        }





    }
}
