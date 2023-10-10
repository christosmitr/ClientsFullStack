using ClientsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace ClientsAPI.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Phones> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<Phones>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Client>().
                HasOne(c => c.Phones).
                WithOne().
                HasForeignKey<Phones>(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
