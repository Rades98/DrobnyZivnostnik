namespace Application.Services
{
    using Application.Database;
    using AutoMapper;
    using Domain;
    using Domain.Entities.Common;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;


    public class BaseService<TModel, TEntity> where TModel : class where TEntity : Entity
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
