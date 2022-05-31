using HealthChecks.UI.Client;
using InstitutoApi.Data;
using InstitutoApi.Dto.Mappers;
using InstitutoApi.Health;
using InstitutoApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InstitutoApi
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

            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<InstitutoContext>(
                opts => opts.UseNpgsql(connectionString)
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InstitutoApi", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            services.AddScoped<IGetAlumnoService, GetAlumnoService>();
            services.AddScoped<IAlumnoMapper, AlumnoMapper>();
            services.AddScoped<IAlumnoService, AlumnoService>();

            // Registers required services for health checks
            services.AddHealthChecks()
                // Add a health check for a SQL Server database
                .AddCheck(
                    "OrderingDB-check",
                    new SqlConnectionHealthCheck(Configuration["DbContextSettings:ConnectionString"]),
                    HealthStatus.Unhealthy,
                    new string[] { "Comprobación BD" });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InstitutoApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/hc");
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    // Predicate = check => check.Tags.Contains("readiness"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

            });
        }
    }
}
