using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using ZipPay.Business.Mapper;

namespace ZipPay.Business
{
    public static class Dependencies
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(thisAssembly);
            services.AddAutoMapper(thisAssembly);
            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
