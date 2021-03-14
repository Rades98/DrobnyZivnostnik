namespace DrobnyZivnostnik.Database
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IAppDbContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
