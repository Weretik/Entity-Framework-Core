using _3.Relationship_between_models_and_inheritance;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
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
}
