using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingMeters.Models;

namespace ParkingMeters.DB
{
    public class ParkingContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ParkingMeter> ParkingMeters { get; set; }

        public ParkingContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetValue<string>("DbConnectionString"));
        }
    }
}
