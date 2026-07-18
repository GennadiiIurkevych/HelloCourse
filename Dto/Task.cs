using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public sealed class ProductDto
        {
            public int Id { get; init; }
            public string Name { get; init; } = "";
            public string Category { get; init; } = "";
            public decimal Price { get; init; }
            public int StockCount { get; init; }
            public bool IsAvailable { get; init; }
        }

        public enum OrderStatus
        {
            Pending,
            Shipped,
            Cancelled
        }

        public static class ProductMapper
        {
            public static ProductDto ToDto(RawProduct raw)
            {
                if (raw.Name  == null && raw.CategoryName == null)

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

        //public static class OrderMapper
        //{
        //    public static OrderDto ToDto(RawOrder raw)
        //    {
        //        if (raw == null)
        //            Console.WriteLine("Make the order!");

        //        // Попробуем распарсить статус, по умолчанию — Pending
        //        if (!Enum.TryParse<OrderStatus>(raw.Status ?? string.Empty, true, out var status))
        //        {
        //            status = OrderStatus.Pending;
        //        }

        //        return new OrderDto
        //        {
        //            OrderId = raw.OrderId,
        //            CustomerName = raw.CustomerName ?? string.Empty,
        //            ProductIds = raw.ProductIds?.AsReadOnly(),
        //            Status = status,
        //            CreatedAt = raw.CreatedAt
        //        };
        //    }

        //    public static List<OrderDto> ToDtoList(List<RawOrder> raws)
        //    {
        //        if (raws == null)
        //            throw new ArgumentNullException(nameof(raws));

        //        return raws.Select(ToDto).ToList();
        //    }
        //}



        public sealed class OrderDto
        {
            public int OrderId { get; init; }
            public string CustomerName { get; init; } = "";
            public IReadOnlyList<int>? ProductIds { get; init; }
            public OrderStatus Status { get; init; }
            public DateTime CreatedAt { get; init; }
        }

        static void Main(string[] args)
        {
            var products = ProductMapper.ToDtoList(rawProducts);

            var selectedProduct = products.Where(p => p.IsAvailable == true).OrderBy(p => p.Price);

            foreach (var p in selectedProduct)
            {
                Console.WriteLine($"{p.Id}, {p.Name}, {p.Category}, {p.Price}, {p.StockCount}, {p.IsAvailable}");
            }

            Console.WriteLine("________________________________");

            

            foreach (var p in selectedProduct)
            {
                if (p.Category == "Electronics" && p.Price < 500)

                Console.WriteLine($"{p.Id}, {p.Name}, {p.Category}, {p.Price}, {p.StockCount}, {p.IsAvailable}");
            }


            //var orders = OrderMapper.ToDtoList(rawOrders);

            //Console.WriteLine("________________________________");
            //var selectedProducts = from p in rawProducts select p;
            //foreach (var product in selectedProducts)
            //{
            //    Console.WriteLine($"{product.Name}, {product.CategoryName}, {product.PriceUsd}, {product.StockCount}, {product.IsActive}");
            //}
        }
    }
}
