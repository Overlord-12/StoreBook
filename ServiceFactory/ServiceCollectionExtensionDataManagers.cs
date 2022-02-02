using DataManagers;
using DataManagers.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFactory
{
    public static class ServiceCollectionExtensionDataMager
    {
        public static IServiceCollection AddProcessManagers(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeDataManagers, EmployeeDataManagers>();
            return services;
        }
    }
}
