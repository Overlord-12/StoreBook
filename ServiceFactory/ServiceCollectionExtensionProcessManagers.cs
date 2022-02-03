using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagers;
using DataManagers.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessManager;
using ProcessManager.Interface;

namespace ServiceFactory
{
    public static class ServiceCollectionExtensionProcessManagers
    {
        public static IServiceCollection AddDataManagers(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeProcessManager, EmployeeProcessManager>();
            return services;
        }
    }
}
