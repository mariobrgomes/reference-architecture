using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RIFS.Core.Application.Behaviors;
using WebApi.DependencyInjection;

namespace WebApi
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
            services.AddControllers();
            services.AddLogging();
            services.AddUseCases();

            services.AddSwaggerGen(c => c.SwaggerDoc(
                "v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName),
                    Version = "v1"
                }));


            //services.AddValidators();
            //services.AddFailFastValidationBehavior();
            //services.AddMediatorToUseCases();

            AssemblyScanner.FindValidatorsInAssembly(AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "Application"))
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidationBehavior<,>));

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "Application"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
