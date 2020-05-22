using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ROAPI.Api.Configurations;
using ROAPI.Api.Extensions;
using ROAPI.Api.Extensions.Dependencies;
using AutoMapper;
using ROAPI.Api.Extensions.Depencies;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Pomelo.Extensions.Caching;

namespace ROAPI.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMySqlCache(options => {
                options.ReadConnectionString = Configuration.GetConnectionString("CacheConnection");
                options.WriteConnectionString = Configuration.GetConnectionString("CacheConnection");
                options.SchemaName = Configuration.GetSection("CacheConfiguration").GetValue<string>("Schema");
                options.TableName = Configuration.GetSection("CacheConfiguration").GetValue<string>("Table");
            });
            services.AddJwtServices(Configuration);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerServices();
            services.AddConnectionDbService(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddAccountDependencies();
            services.AddConfigurationDependencies();
            services.AddSystemDependencies();
            services.AddGlobalExceptionHandlerMiddleware();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.AddSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseGlobalExceptionHandlerMiddleware();
        }
    }
}
