namespace Persistence
{
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderSeedExtensions
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            return modelBuilder;
        }
    }
}