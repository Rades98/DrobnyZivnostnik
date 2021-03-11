namespace DrobnyZivnostnik.Services
{
    using AutoMapper;
    using Database;
    using Xamarin.Forms;

    public class BaseService
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
    }
}
