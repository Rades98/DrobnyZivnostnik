namespace DrobnyZivnostnik.Database
{
    using System;
    using System.IO;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public sealed class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }

        public AppDbContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Hx82ax.sqlite");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
