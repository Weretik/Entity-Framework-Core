namespace _2.Fluent_API_Data_Annotations_migration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProductdbContext())
            {
                var allProducts = db.Products.ToList();

                foreach (var product in allProducts)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }
    }
}
