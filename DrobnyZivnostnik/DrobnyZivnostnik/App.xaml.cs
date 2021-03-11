namespace DrobnyZivnostnik
{
    using AutoMapper;
    using Database;
    using Database.Entities;
    using Models.Address;
    using Models.User;
    using Services;
    using Services.Interfaces;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CustomInitialized();

            MainPage = new MasterPage();
        }

        private static void CustomInitialized()
        {
            DependencyService.RegisterSingleton(CreateAutoMapper());
            DependencyService.Register<IAppDbContext, AppDbContext>();

            //Services
            DependencyService.Register<IAddressService, AddressService>();
            DependencyService.Register<IUserService, UserService>();
        }

        private static IMapper CreateAutoMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<User, UserListModel>()
                    .ForMember(listModel => listModel.Name, opt => opt.MapFrom(user => user.Name + " " + user.Surname));
                cfg.CreateMap<UserModel, User>();
            }).CreateMapper();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
