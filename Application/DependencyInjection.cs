namespace Application
{
    using AutoMapper;
    using Database;
    using Domain.Entities;
    using Microsoft.Extensions.DependencyInjection;
    using Models.Address;
    using Models.TravelOrder;
    using Models.User;
    using Models.Vehicle;
    using Services;
    using Services.Interfaces;
    using Xamarin.Forms;

    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ITravelOrderService, TravelOrderService>();

            services.AddAutoMapper(typeof(MappingProfiler));

            return services;
        }

        public static void RegisterApplicationDependencies()
        {
            DependencyService.Register<IAppDbContext, AppDbContext>();

            DependencyService.Register<IAddressService, AddressService>();
            DependencyService.Register<IUserService, UserService>();
            DependencyService.Register<IVehicleService, VehicleService>();
            DependencyService.Register<ITravelOrderService, TravelOrderService>();

            DependencyService.RegisterSingleton(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<AddressModel, Address>();

                cfg.CreateMap<TravelOrderFront, TravelOrderFrontModel>();
                cfg.CreateMap<TravelOrderFrontModel, TravelOrderFront>();

                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();

                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();
            }).CreateMapper());
        }
    }
}
