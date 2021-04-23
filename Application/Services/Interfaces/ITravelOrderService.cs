namespace Application.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Models.TravelOrder;

    public interface ITravelOrderService : IBaseService<TravelOrderFrontModel>
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
