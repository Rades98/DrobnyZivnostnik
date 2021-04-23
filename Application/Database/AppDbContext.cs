namespace Application.Database
{
    using System;
    using System.IO;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public sealed class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<TravelOrderFront> TravelOrderFront { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public AppDbContext()
        {
#if DEBUG
            this.Database.EnsureDeleted(); // ONLY FOR DEBUG
#endif
            this.Database.EnsureCreated();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Hx82ax.sqlite");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }
    }
}
