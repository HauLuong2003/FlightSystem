using FlightSystem.Domain.Entities;
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
        public DbSet<GroupDocument> GroupDocuments { get; set; }
        public DbSet<GroupDocumentType> GroupDocumentsTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary key for GroupDocument
            modelBuilder.Entity<GroupDocument>()
                .HasKey(gd => new { gd.GroupId, gd.DocumentId });

            // Relationship between Group and GroupDocument (one-to-many)
            modelBuilder.Entity<GroupDocument>()
                .HasOne(gd => gd.Group)
                .WithMany(g => g.GroupDocuments)
                .HasForeignKey(gd => gd.GroupId);

            // Relationship between Document and GroupDocument (one-to-many)
            modelBuilder.Entity<GroupDocument>()
                .HasOne(gd => gd.Document)
                .WithMany(d => d.GroupDocuments)
                .HasForeignKey(gd => gd.DocumentId);

            modelBuilder.Entity<GroupDocumentType>()
           .HasKey(gd => new { gd.GroupId, gd.TypeId });
            modelBuilder.Entity<GroupDocumentType>()
             .HasOne(gd => gd.Group)
             .WithMany(g => g.GroupDocumentTypes)
             .HasForeignKey(gd => gd.GroupId);

            // Relationship between Document and GroupDocument (one-to-many)
            modelBuilder.Entity<GroupDocumentType>()
                .HasOne(gd => gd.DocumentType)
                .WithMany(d => d.GroupDocumentTypes)
                .HasForeignKey(gd => gd.TypeId);
        }
    }
}
