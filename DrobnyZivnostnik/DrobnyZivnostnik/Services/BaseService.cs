namespace DrobnyZivnostnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Database;
    using Database.Entities;
    using Extensions;
    using Microsoft.EntityFrameworkCore;
    using Xamarin.Forms;

    public class BaseService<TModel, TEntity> where TModel : class where TEntity : class, IEntity
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        protected IMapper Mapper => _mapper;
        protected AppDbContext DbContext => _dbContext;

        public BaseService()
        {
            _mapper = DependencyService.Get<IMapper>();
            _dbContext = (AppDbContext)DependencyService.Get<IAppDbContext>();
        }
        
        /// <inheritdoc/>
        public async Task AddAsync(TModel model)
        {
            DbContext.Set<TEntity>().Add(Mapper.Map<TEntity>(model));
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid TEntityId)
        {
            var entity = await DbContext.Set<TEntity>().FindAsync(TEntityId);

            entity.SoftDelete();

            DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
        }
    }
}
