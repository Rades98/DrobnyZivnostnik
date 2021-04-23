namespace AxiosServices
{
    using DrobnyZivnostnik.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Interfaces;
    using Xamarin.Forms;

    public static class AxiosServicesDependencyInjection
    {
        public static IServiceCollection RegisterAxiosServices(this IServiceCollection services)
        {
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }

        public static void RegisterAxiosServices()
        {
            DependencyService.Register<ILocalizationService, LocalizationService>();
            DependencyService.Register<IMessageService, MessageService>();
        }
    }
}
