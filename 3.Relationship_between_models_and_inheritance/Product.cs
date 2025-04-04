using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3.Relationship_between_models_and_inheritance;

public partial class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public double ActionPrice { get; set; }
    public string? Description { get; set; }
    public string? DescriptionField1 { get; set; }
    public string? DescriptionField2 { get; set; }
    public string? ImageURL { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public List<Cart> Cart { get; set; } = null!;
    public List<KeyParams> KeyWords { get; set; } = null!;
}

public class Cart
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }

    public List<Cart> Cart { get; set; } = null!;
}

public class Category
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Icon { get; set; }

    public List<Product> Products { get; set; } = null!;
}

public class KeyParams
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid KeyWordsId { get; set; }
    public Word KeyWords { get; set; } = null!;
}

public class Word
{
    public Guid Id { get; set; }
    public string? Header { get; set; }
    public string? KeyWord { get; set; }

    public List<KeyParams> ProductLink { get; set; } = null!;
}