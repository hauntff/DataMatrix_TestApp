using DataMatrix_TestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataMatrix_TestApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactUser> ContactUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // public AppDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DataMatrixTestDB;TrustServerCertificate=true;MultipleActiveResultSets=true");
        
    }
}
