namespace DrobnyZivnostnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Database.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.TravelOrder;

    class TravelOrderService : BaseService<TravelOrderFrontModel, TravelOrderFront>, ITravelOrderService
    {
        /// <inheritdoc />
        public async Task<ICollection<TravelOrderFrontModel>> GetAsync()
        {
            var result = await DbContext.TravelOrderFront
                .AsNoTracking()
                .Where(x=> !x.Deleted)
                .ToListAsync();

            return Mapper.Map<ICollection<TravelOrderFrontModel>>(result);
        }

        /// <inheritdoc />
        public async Task<ICollection<TravelOrderFrontModel>> GetFilteredAsync(Expression<Func<TravelOrderFront, bool>> filter)
        {
            var result = await DbContext.TravelOrderFront.Where(filter).ToListAsync();

            return Mapper.Map<ICollection<TravelOrderFrontModel>>(result);
        }
    }
}
