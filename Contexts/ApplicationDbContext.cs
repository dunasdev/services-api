using Microsoft.EntityFrameworkCore;
using Services.Api.Models;

namespace Services.Api.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Worker> Workers => Set<Worker>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
            modelBuilder.Entity<Store>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
            modelBuilder.Entity<Worker>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Client)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // Desativa o delete em cascata, pois estava com referência circular

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Store)
                .WithMany(st => st.Services)
                .HasForeignKey(s => s.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Worker)
                .WithMany(w => w.Services)
                .HasForeignKey(s => s.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Store)
                .WithMany(st => st.Workers)
                .HasForeignKey(w => w.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Store)
                .WithMany(st => st.Clients)
                .HasForeignKey(c => c.StoreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
