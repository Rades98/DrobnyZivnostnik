namespace Application
{
    using Database;
    using Microsoft.Extensions.DependencyInjection;
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

            DependencyService.RegisterSingleton(new MappingProfiler());
        }
    }
}
