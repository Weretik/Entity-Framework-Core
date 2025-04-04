using Microsoft.EntityFrameworkCore;
using System.Text;
namespace _3.Relationship_between_models_and_inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            DeletedCreatedDB();
            AddData();
            AddCartItems();
            ShowData();

        }

        public static void AddData()
        { 
            using (var db = new ProductdbContext())
            {
                var users = new List<User>
                {
                    new() { Id = Guid.NewGuid(), Name = "Юлия", Login = "yulia", Password = "123", Email = "yulia@example.com" },
                    new() { Id = Guid.NewGuid(), Name = "Іван", Login = "ivan", Password = "456", Email = "ivan@example.com" }
                };
                db.AddRange(users);
                var categories = new List<Category>
                {
                    new() { Id = Guid.NewGuid(), Name = "Зимова форма", Icon = "snow.png" },
                    new() { Id = Guid.NewGuid(), Name = "Літня форма", Icon = "sun.png" },
                    new() { Id = Guid.NewGuid(), Name = "Захист рук", Icon = "gloves.png" }
                };
                db.AddRange(categories);
                var products = new List<Product>
                {
                    new() { Id = Guid.NewGuid(), Name = "Зимова куртка", Price = 1200, ActionPrice = 1100, Category = categories[0] },
                    new() { Id = Guid.NewGuid(), Name = "Комбінезон", Price = 1500, ActionPrice = 1400, Category = categories[0] },
                    new() { Id = Guid.NewGuid(), Name = "Футболка", Price = 400, ActionPrice = 350, Category = categories[1] },
                    new() { Id = Guid.NewGuid(), Name = "Літні штани", Price = 600, ActionPrice = 550, Category = categories[1] },
                    new() { Id = Guid.NewGuid(), Name = "Рукавиці утеплені", Price = 300, ActionPrice = 280, Category = categories[2] },
                    new() { Id = Guid.NewGuid(), Name = "Рукавиці гумові", Price = 200, ActionPrice = 180, Category = categories[2] },
                    new() { Id = Guid.NewGuid(), Name = "Рукавиці брезентові", Price = 250, ActionPrice = 230, Category = categories[2] }
                };
                db.AddRange(products);
                var words = new List<Word>
                {
                    new() { Id = Guid.NewGuid(), Header = "зима", KeyWord = "зимні" },
                    new() { Id = Guid.NewGuid(), Header = "літо", KeyWord = "літні" },
                    new() { Id = Guid.NewGuid(), Header = "захист", KeyWord = "руки" }
                };
                db.AddRange(words);
                var keyParams = new List<KeyParams>
                {
                    new() { Id = Guid.NewGuid(), Product = products[0], KeyWords = words[0] },
                    new() { Id = Guid.NewGuid(), Product = products[1], KeyWords = words[0] },
                    new() { Id = Guid.NewGuid(), Product = products[2], KeyWords = words[1] },
                    new() { Id = Guid.NewGuid(), Product = products[3], KeyWords = words[1] },
                    new() { Id = Guid.NewGuid(), Product = products[4], KeyWords = words[2] },
                    new() { Id = Guid.NewGuid(), Product = products[5], KeyWords = words[2] },
                    new() { Id = Guid.NewGuid(), Product = products[6], KeyWords = words[2] }
                };
                db.AddRange(keyParams);

                db.SaveChanges();
            }
        }
        public static void AddCartItems()
        {
            using var db = new ProductdbContext();

            var user1 = db.Users.FirstOrDefault(u => u.Login == "yulia");
            var user2 = db.Users.FirstOrDefault(u => u.Login == "ivan");

            var products = db.Products.ToList();


            var cartItems = new List<Cart>
            {
                new() { Id = Guid.NewGuid(), UserId = user1.Id, ProductId = products[0].Id },
                new() { Id = Guid.NewGuid(), UserId = user1.Id, ProductId = products[1].Id },
                new() { Id = Guid.NewGuid(), UserId = user2.Id, ProductId = products[2].Id },
                new() { Id = Guid.NewGuid(), UserId = user2.Id, ProductId = products[3].Id }
            };

            db.AddRange(cartItems);
            db.SaveChanges();

            Console.WriteLine("Кошик успішно заповнено.");
        }
        public static void ShowData()
        {
            using (var db = new ProductdbContext())
            {
                var products = db.Products
                    .Include(p => p.Cart)
                        .ThenInclude(c => c.User)
                    .Include(p => p.Category)
                    .Include(p => p.KeyWords)
                        .ThenInclude(kp => kp.KeyWords)
                    .ToList();

                var users = db.Users
                    .Include(u => u.Cart)
                        .ThenInclude(c => c.Product)
                            .ThenInclude(p => p.KeyWords)
                                .ThenInclude(kp => kp.KeyWords)
                    .ToList();

                var categories = db.Categories
                    .Include(c => c.Products)
                        .ThenInclude(p => p.KeyWords)
                            .ThenInclude(kp => kp.KeyWords)
                    .ToList();


                // ========== USER BLOCK ==========
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("User");

                foreach (var user in users)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"- {user.Name}");

                    foreach (var cartItem in user.Cart)
                    {
                        var product = cartItem.Product;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("--");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{product.Name} ");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("(");

                        foreach (var kw in product.KeyWords)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{kw.KeyWords.KeyWord} | ");
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(")");
                    }
                }

                Console.WriteLine();

                // ========== CATEGORY BLOCK ==========
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Category");

                foreach (var category in categories)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"- {category.Name}");

                    foreach (var product in category.Products)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("--");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{product.Name} ");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("(");

                        foreach (var kw in product.KeyWords)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{kw.KeyWords.KeyWord} | ");
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(")");
                    }
                }

                Console.ResetColor();
                Console.WriteLine("\nfinish");
            }

        }
        public static void DeletedCreatedDB()
        {
            using (var db = new ProductdbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
