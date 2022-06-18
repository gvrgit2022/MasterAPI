 
using Master.Application;
using Master.Infrastructure;
using MasterAPI.ActionFilters;
using MasterAPI.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI
{
    
        // This method gets called by the runtime. Use this method to add services to the container.
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


                services.AddApplication(Configuration);
            //services.AddTransient<EnableRequestReReadingMiddleware>();
            //services.AddTransient<TraceIdAsRequestIdIMiddleware>();
            //services.AddControllers();
            services.AddMvc(
                options =>
                {
                    //options.OutputFormatters.Insert(0, new JsonApiOutputFormatter());
                    options.Filters.Add<ExceptionActionFilter>();
                    options.Filters.Add<ValidationActionFilter>();
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //services.AddHealthChecks()
            //    .AddSqlServer(Configuration.GetConnectionString("OrganizationDb"));

            services.AddInfrastructure(Configuration);

                services.AddLogging(s => s.AddConsole());
                services.AddAutoMapper(typeof(Startup));




                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MasterAPI", Version = "v1" });
                });
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MasterAPI v1"));
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
}
