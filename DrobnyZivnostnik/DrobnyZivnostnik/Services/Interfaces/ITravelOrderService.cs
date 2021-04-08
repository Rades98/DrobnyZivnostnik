namespace DrobnyZivnostnik.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Database.Entities;
    using Models.TravelOrder;

    interface ITravelOrderService : IBaseService<TravelOrderFrontModel>
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TravelOrderFrontModel>> GetAsync();

        /// <summary>
        /// Gets the filtered asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        Task<ICollection<TravelOrderFrontModel>> GetFilteredAsync(Expression<Func<TravelOrderFront, bool>> filter);
    }
}
