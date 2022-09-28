using Case_Parking_Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace Case_Parking_Microservices.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Parking> Parkings { get; set; }
    }
}
