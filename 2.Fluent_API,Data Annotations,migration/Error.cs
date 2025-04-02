using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Fluent_API_Data_Annotations_migration
{
    [NotMapped]
    public class Error
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Request { get; set; }
        public StatusCode Status { get; set; }
    }
}
