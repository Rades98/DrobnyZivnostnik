namespace DrobnyZivnostnik.Services.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IBaseService<TModel> where TModel : class
    {
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task AddAsync(TModel model);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid addressId);
    }
}
