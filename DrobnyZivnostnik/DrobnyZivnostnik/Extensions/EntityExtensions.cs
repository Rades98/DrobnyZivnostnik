namespace DrobnyZivnostnik.Extensions
{
    using Database.Entities;

    public static class EntityExtensions
    {
        /// <summary>
        /// Soft delete for entities
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void SoftDelete(this Entity entity)
        {
            entity.Deleted = true;
        }
    }
}
