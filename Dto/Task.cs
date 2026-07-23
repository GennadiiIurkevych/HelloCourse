using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dto
{
    internal class Task
    {
        private static readonly List<RawProduct> rawProducts = new List<RawProduct>
        {
            new() { Id = 1,  Name = "Laptop",      CategoryName = "Electronics", PriceUsd = 999.99,  StockCount = 5,  IsActive = true  },
            new() { Id = 2,  Name = "Phone",       CategoryName = "Electronics", PriceUsd = 499.99,  StockCount = 12, IsActive = true  },
            new() { Id = 3,  Name = "Headphones",  CategoryName = "Electronics", PriceUsd = 79.99,   StockCount = 0,  IsActive = true  },
            new() { Id = 4,  Name = "T-Shirt",     CategoryName = "Clothing",    PriceUsd = 19.99,   StockCount = 50, IsActive = true  },
            new() { Id = 5,  Name = "Jeans",       CategoryName = "Clothing",    PriceUsd = 49.99,   StockCount = 30, IsActive = false },
            new() { Id = 6,  Name = "Coffee Maker",CategoryName = "Kitchen",     PriceUsd = 89.99,   StockCount = 8,  IsActive = true  },
            new() { Id = 7,  Name = "Blender",     CategoryName = "Kitchen",     PriceUsd = 39.99,   StockCount = 0,  IsActive = true  },
            new() { Id = 8,  Name = "Desk Lamp",   CategoryName = "Office",      PriceUsd = 24.99,   StockCount = 20, IsActive = true  },
        };

        private static readonly List<RawOrder> rawOrders = new List<RawOrder>
        {
            new() { OrderId = 101, CustomerId = 1, CustomerName = "Alice",   ProductIds = new() { 1, 3 },    Status = "shipped",   CreatedAt = new DateTime(2024, 1, 10) },
            new() { OrderId = 102, CustomerId = 2, CustomerName = "Bob",     ProductIds = new() { 2, 4, 6 }, Status = "pending",   CreatedAt = new DateTime(2024, 2, 5)  },
            new() { OrderId = 103, CustomerId = 1, CustomerName = "Alice",   ProductIds = new() { 5 },       Status = "cancelled", CreatedAt = new DateTime(2024, 2, 20) },
            new() { OrderId = 104, CustomerId = 3, CustomerName = "Charlie", ProductIds = new() { 1, 2 },    Status = "shipped",   CreatedAt = new DateTime(2024, 3, 1)  },
            new() { OrderId = 105, CustomerId = 2, CustomerName = "Bob",     ProductIds = new() { 8 },       Status = "pending",   CreatedAt = new DateTime(2024, 3, 15) },
        };

        public interface IDiscountStrategy
        {
            abstract decimal ApplyDiscount(decimal originalPrice);
            string Description { get; }
        }

        public interface IShippingMethod
        {
            decimal Cost { get; }
            int EstimatedDays { get; }
            string Name { get; }
        }

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
            public decimal percent = 15m;

            public PercentageDiscount(decimal percent)
            {

            }
            public decimal ApplyDiscount(decimal originalPrice)
            {
                if (percent >= 0 && percent <= 100)
                {
                    return originalPrice - (originalPrice / 100 * percent);
                }
                throw new ArgumentOutOfRangeException("The discount is too much");
            }
            public string Description => $"{percent}% off";
        }

        public sealed class FixedAmountDiscount : IDiscountStrategy
        {
            public decimal amount = 10m;

            public FixedAmountDiscount(decimal amount)
            {

            }
            public decimal ApplyDiscount(decimal originalPrice)
            {
                if (originalPrice < amount)
                {
                    Console.WriteLine("The price can't be negative");
                }
                return originalPrice - amount;
            }
            public string Description => $"${amount} off";
        }



        public static class PriceCalculator
        {
            public static decimal CalculateFinalPrice(ProductDto product, IDiscountStrategy discount)
            {
                return discount.ApplyDiscount(product.Price);
            }
            public static void PrintReceipt(ProductDto product, IDiscountStrategy discount)
            {
                var finalPrice = CalculateFinalPrice(product, discount);
                Console.WriteLine($"Product: {product.Name}, Original price: {product.Price}, Discount: {discount.Description}, Final price: {finalPrice}");
            }
        }




        public class RawProduct
        {
            public int Id { get; init; }
            public string? Name { get; init; }
            public string? CategoryName { get; init; }
            public double PriceUsd { get; init; }
            public int StockCount { get; init; }
            public bool IsActive { get; init; }
        }

        public class RawOrder
        {
            public int OrderId { get; init; }
            public int CustomerId { get; init; }
            public string? CustomerName { get; init; }
            public List<int>? ProductIds { get; init; }
            public string? Status { get; init; }
            public DateTime CreatedAt { get; init; }
        }

        public enum OrderStatus
        {
            Pending,
            Shipped,
            Cancelled
        }

        public sealed class ProductDto
        {
            public int Id { get; init; }
            public string Name { get; init; } = "";
            public string Category { get; init; } = "";
            public decimal Price { get; init; }
            public int StockCount { get; init; }
            public bool IsAvailable { get; init; }
        }

        public static class ProductMapper
        {
            public static ProductDto ToDto(RawProduct raw)
            {
                if (raw.Name == null)

                    Console.WriteLine("Unknown");

                return new ProductDto
                {
                    Id = raw.Id,
                    Name = raw.Name ?? "",
                    Category = raw.CategoryName ?? "",
                    Price = (decimal)raw.PriceUsd,
                    StockCount = raw.StockCount,
                    IsAvailable = raw.IsActive
                };
            }
            public static List<ProductDto> ToDtoList(List<RawProduct> raws)
            {
                if (raws == null)

                    Console.WriteLine("Raws products list is null");

                return raws.Select(ToDto).ToList();
            }


        }

        public sealed class OrderDto
        {
            public int OrderId { get; init; }
            public string CustomerName { get; init; } = "";
            public int CustomerId { get; init; }
            public IReadOnlyList<int>? ProductIds { get; init; }
            public OrderStatus Status { get; init; }
            public DateTime CreatedAt { get; init; }
        }

        public static class OrderMapper
        {
            public static OrderDto ToDto(RawOrder raw)
            {
                if (raw.CustomerName is null)
                    Console.WriteLine("Unknown!");

                return new OrderDto
                {
                    OrderId = raw.OrderId,
                    CustomerName = raw.CustomerName ?? string.Empty,
                    CustomerId = raw.CustomerId,
                    ProductIds = raw.ProductIds?.AsReadOnly(),
                    Status = ParseStatus(raw.Status),
                    CreatedAt = raw.CreatedAt
                };
            }

            public static List<OrderDto> ToDtoList(List<RawOrder> raws)
            {
                if (raws == null)
                    Console.WriteLine("Raws order list is null");

                return raws.Select(ToDto).ToList();
            }
        }
        private static OrderStatus ParseStatus(string status)
        {
            switch (status)
            {
                case "pending": return OrderStatus.Pending;
                case "shipped": return OrderStatus.Shipped;
                case "cancelled": return OrderStatus.Cancelled;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), $"Unknown status: {status}");
            }
        }

        static void Main(string[] args)
        {
            var products = ProductMapper.ToDtoList(rawProducts);

            var selectedProduct = products.Where(p => p.IsAvailable == true).OrderBy(p => p.Price);
            foreach (var p in selectedProduct)
                Console.WriteLine($"{p.Id}, {p.Name}, {p.Category}, {p.Price}, {p.StockCount}, {p.IsAvailable}");

            Console.WriteLine("________________________________");

            foreach (var p in selectedProduct)
                if (p.Category == "Electronics" && p.Price < 500)
                    Console.WriteLine($"{p.Id}, {p.Name}, {p.Category}, {p.Price}, {p.StockCount}, {p.IsAvailable}");

            Console.WriteLine("________________________________");

            var selectedCategory = products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.Average(p => p.Price)); //.Average() - метод, що повертає середнє арифметичне 

            foreach (var p in selectedCategory)
                Console.WriteLine($"{p.Key}: {p.Value}");

            Console.WriteLine("________________________________");

            var selectedCategoryMax = products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.MaxBy(p => p.Price));
            foreach (var p in selectedCategoryMax)
                Console.WriteLine($"{p.Key}: {p.Value.Price}");

            Console.WriteLine("________________________________");

            var productsFalseCount = products.Count(p => !p.IsAvailable);
            Console.WriteLine(productsFalseCount);

            Console.WriteLine("********************************");

            var orderList = OrderMapper.ToDtoList(rawOrders);

            var selectedShipped = orderList.OrderBy(p => p.CreatedAt);
            foreach (var item in selectedShipped)
                if (item.Status == OrderStatus.Shipped)
                    Console.WriteLine($"{item.OrderId} - {item.CustomerName} - {item.Status} - {item.CreatedAt}");

            Console.WriteLine("********************************");

            var selectedStatusCount = orderList.GroupBy(s => s.Status).ToDictionary(g => g.Key, g => g.Count());
            foreach (var item in selectedStatusCount)
                Console.WriteLine($"{item.Key}: {item.Value}");

            Console.WriteLine("********************************");

            var selectedProducrIds = orderList.Where(s => s.ProductIds.Contains(1) == true);
            foreach (var s in selectedProducrIds)
                Console.WriteLine($"{s.CustomerName}: {s.OrderId}");

            Console.WriteLine("********************************");

            foreach (var p in orderList)
                if (p.Status == OrderStatus.Cancelled)
                    Console.WriteLine($"{p.CustomerId}, {p.OrderId}, {p.CustomerName}");

            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");

            var originalPrice = ProductMapper.ToDtoList(rawProducts).ToDictionary(o => o.Name, o => o.Price);
            foreach (var p in originalPrice)

                Console.WriteLine($"Product Id: {p.Key} - Price: {p.Value}");

            Console.WriteLine("-----Task1 Block6-----");

            NoDiscount noDiscount = new NoDiscount();

            Console.WriteLine($"{noDiscount.ApplyDiscount(originalPrice["Phone"])}, Discount: {noDiscount.Description}");

            Console.WriteLine("______________________");

            var percentageDiscount = new PercentageDiscount(15m);

            Console.WriteLine($"{Math.Round(percentageDiscount.ApplyDiscount(originalPrice["Phone"]), 2)}, Discount: {percentageDiscount.Description}");

            Console.WriteLine("______________________");

            var fixedAmountDiscount = new FixedAmountDiscount(10m);

            Console.WriteLine($"{fixedAmountDiscount.ApplyDiscount(originalPrice["Phone"])}, Discount: {fixedAmountDiscount.Description}");

            Console.WriteLine("______________________");
            Console.WriteLine("*****Task2 Block6*****");

            IDiscountStrategy[] priceCalculator = { new NoDiscount(), new PercentageDiscount(15m), new FixedAmountDiscount(10m) };

            foreach (var p in products)
            {          
                foreach(var calc in priceCalculator)
                    PriceCalculator.PrintReceipt(p, calc);
                Console.WriteLine();
            }


        }
    }
}
