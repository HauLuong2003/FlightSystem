using FlightSystem.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FlightSystemDBContext : DbContext
    {
        public FlightSystemDBContext(DbContextOptions<FlightSystemDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
      
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Flight> Flights  { get;set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }



    }
}
