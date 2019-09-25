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
        public DynamicCorsPolicyConfigContext(DbContextOptions<DynamicCorsPolicyConfigContext> options)
            : base(options)
        {
        }

        public DbSet<DynamicCorsPolicy.Config.Data.AllowedOrigins> AllowedOrigins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AllowedOrigins>().HasData(new AllowedOrigins() { Id = 1, Enabled = true, Name = "client1", URL = "https://localhost:44300/" });
            modelBuilder.Entity<AllowedOrigins>().HasData(new AllowedOrigins() { Id = 2, Enabled = false, Name = "client2", URL = "http://localhost:58157" });
            modelBuilder.Entity<AllowedOrigins>().HasData(new AllowedOrigins() { Id = 3, Enabled = true, Name = "client3", URL = "http://localhost:38151" });

        }
    }
}
