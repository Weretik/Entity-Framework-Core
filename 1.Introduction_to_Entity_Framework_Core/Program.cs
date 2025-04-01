using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace _1.Introduction_to_Entity_Framework_Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Завдання 1
                Розробіть консольну програму з використанням одного списку з типом (List< ваш вибір >) одного з варіантів.

                1. Магазин – Product
                1) + Id: Guid
                2) + Name: string
                3) + Cost: double
                4) + Description: string
                5) + Quantity: int

                - Заповніть ваш список значеннями (10 значень).
                - Виведіть на екран значення за індексом > 1, 5, 0, 7
                - Знайдіть та виведіть індекси > 1, 5 за властивістю Id
                - Знайдіть та виведіть індекси > 0, 7 за властивістю Name
            */

            /*
            using (var context = new ProductsContext())
            {
                context.Products.Add(new Product { Name = "Apple", Cost = 1.2m, Description = "Green Apple", Quantity = 100 });
                context.Products.Add(new Product { Name = "Banana", Cost = 0.5m, Description = "Yellow Banana", Quantity = 200 });
                context.Products.Add(new Product { Name = "Orange", Cost = 1.0m, Description = "Orange Orange", Quantity = 150 });
                context.Products.Add(new Product { Name = "Pineapple", Cost = 2.5m, Description = "Sweet Pineapple", Quantity = 50 });
                context.Products.Add(new Product { Name = "Mango", Cost = 3.0m, Description = "Juicy Mango", Quantity = 75 });
                context.Products.Add(new Product { Name = "Grapes", Cost = 1.8m, Description = "Black Grapes", Quantity = 120 });
                context.Products.Add(new Product { Name = "Strawberry", Cost = 2.0m, Description = "Red Strawberry", Quantity = 90 });
                context.Products.Add(new Product { Name = "Watermelon", Cost = 1.5m, Description = "Sweet Watermelon", Quantity = 80 });
                context.Products.Add(new Product { Name = "Peach", Cost = 1.7m, Description = "Soft Peach", Quantity = 100 });
                context.Products.Add(new Product { Name = "Pomegranate", Cost = 2.3m, Description = "Red Pomegranate", Quantity = 70 });
                context.SaveChanges();
            }
            */
            using (var context = new ProductsContext())
            {

                var ProductsByIndex1 = from p in context.Products
                                       where p.Id == 1 || p.Id == 5 || p.Id == 0 || p.Id == 7
                                       select p;
                Console.WriteLine("Виведіть на екран значення за індексом > 1, 5, 0, 7");
                foreach (var p in ProductsByIndex1)
                {
                    Console.WriteLine($"{p.Id}: {p.Name} - {p.Cost} грн ({p.Quantity} шт)");
                }

                var ProductsByIndex2 = from p in context.Products
                                       where p.Id >= 1 || p.Id <= 5
                                       orderby p.Id
                                       select p;
                Console.WriteLine("Знайдіть та виведіть індекси > 1, 5 за властивістю Id");
                foreach (var p in ProductsByIndex2)
                {
                    Console.WriteLine($"{p.Id}: {p.Name} - {p.Cost} грн ({p.Quantity} шт)");
                }
                Console.WriteLine("Знайдіть та виведіть індекси > 0, 7 за властивістю Name");
                var ProductsByIndex3 = from p in context.Products
                                       where p.Id <= 7
                                       orderby p.Name
                                       select p;

                foreach (var p in ProductsByIndex3)
                {
                    Console.WriteLine($"{p.Id}: {p.Name} - {p.Cost} грн ({p.Quantity} шт)");

                }

            }
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=199629wetprp");
        }
    }
}
