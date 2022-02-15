using DataManagers;
using DataManagers.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceFactory
{
    public static class ServiceCollectionExtensionDataMager
    {
        public static IServiceCollection AddDataManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserDataManagers, UserDataManagers>();
            services.AddScoped<IBookDataManager, BookDataManager>();
            return services;
        }
    }
}
