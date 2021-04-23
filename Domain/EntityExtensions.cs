namespace Domain
{
    using Entities.Common;

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
