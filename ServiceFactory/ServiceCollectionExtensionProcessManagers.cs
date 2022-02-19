using Microsoft.Extensions.DependencyInjection;
using ProcessManager;
using ProcessManager.Interface;

namespace ServiceFactory
{
    public static class ServiceCollectionExtensionProcessManagers
    {
        public static IServiceCollection AddProcessManagers(this IServiceCollection services)
        {
            services.AddTransient<IUserProcessManager, UserProcessManager>();
            services.AddTransient<IAuthenticationProcessManager, AuthenticationProcessManager>();
            services.AddTransient<IBookProcessManager, BookProcessManager>();
            return services;
        }
    }
}
