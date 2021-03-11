namespace DrobnyZivnostnik.Extensions
{
    using Database.Entities;

    public static class EntityExtensions
    {
        public static void SoftDelete(this IEntity entity)
        {
            entity.Deleted = true;
        }
    }
}
