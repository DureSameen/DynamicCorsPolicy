using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DynamicCorsPolicy.Config.Data;

namespace DynamicCorsPolicy.Config.Models
{
    public class DynamicCorsPolicyConfigContext : DbContext
    {
        public DynamicCorsPolicyConfigContext (DbContextOptions<DynamicCorsPolicyConfigContext> options)
            : base(options)
        {
        }

        public DbSet<DynamicCorsPolicy.Config.Data.AllowedOrigins> AllowedOrigins { get; set; }
    }
}
