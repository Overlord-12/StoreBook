using Microsoft.Extensions.DependencyInjection;
using ProcessManager;
using ProcessManager.Interface;

namespace ServiceFactory
{
    public static class ServiceCollectionExtensionProcessManagers
    {
        public static IServiceCollection AddProcessManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserProcessManager, UserProcessManager>();
            services.AddScoped<IAuthenticationProcessManager, AuthenticationProcessManager>();
            services.AddScoped<IBookProcessManager, BookProcessManager>();
            return services;
        }
    }
}
