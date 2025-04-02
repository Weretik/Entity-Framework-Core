namespace _2.Fluent_API_Data_Annotations_migration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var context = new ProductdbContext();
                var product = context.Products.ToList()[-1];
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    Message = ex.Message,
                    Time = DateTime.Now,
                    Request = "context.Products.ToList()[-1]",
                    Status = StatusCode.Server
                };

                var errors = new List<Error> { error };
                foreach (var err in errors)
                {
                    Console.WriteLine($"[{err.Time}] {err.Status}: {err.Message} (Request: {err.Request})");
                }
            }
        }
    }
}
