using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicCorsPolicy.Config.Data
{
    public class AllowedOrigins
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }

        public string URL { get; set; }

        public bool Enabled { get; set; }

    }
}
