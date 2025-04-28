using AcunMedyaAkademiWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaAkademiWebAPI.Context
{
    public class WebApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YIGITATAMANPC;initial catalog=AcunMedyaAkademiDB;integrated Security=True; TrustServerCertificate=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
