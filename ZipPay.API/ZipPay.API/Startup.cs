﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ZipPay.Data;
using ZipPay.Data.Entities;
using ZipPay.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ZipPay.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZipPay API", Version = "v1" });
            });
            services.AddMediatR(typeof(Startup));
            var assembly = AppDomain.CurrentDomain.Load("ZipPay.Business");
            services.AddMediatR(assembly);
            services.AddDbContext<ZipEntities>();
            ConfigureAppSettings(services);
            ConfigureDependencies(services);
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
        }

        private void ConfigureAppSettings(IServiceCollection services)
        {
            services.Configure<AppSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("ConnectionStrings:DBConnection").Value;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZipPay API V1");
                c.RoutePrefix = string.Empty;
            });
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ZipEntities>();
                context.Database.Migrate();
            }
        }
    }
}
