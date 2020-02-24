using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ZipPay.Data.Repositories.Read;
using ZipPay.Data.Repositories.Write;

namespace ZipPay.Business
{
    public static class Dependencies
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IAccountReadRepository, AccountReadRepository>();
            services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
            return services;
        }
    }
}
