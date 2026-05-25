using Microsoft.EntityFrameworkCore;

namespace project01
{
    public class AppDbContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MetroTicketDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().Property(t => t.Price).HasPrecision(18, 2);
        }
    }
}