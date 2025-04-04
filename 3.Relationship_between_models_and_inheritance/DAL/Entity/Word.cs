using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Word
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? KeyWord { get; set; }

        public List<KeyParams> ProductLink { get; set; } = null!;
    }
}
