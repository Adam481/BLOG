using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.Presentation
{
    public class Startup
    {
                 public IServiceProvider ConfigureServices(IServiceCollection services)
         {
            services.AddMvc();
            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllEnumsAsStrings();
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "DDD_Dropshipping - Ordering Api",
                    Version = "v2",
                    Description = "DDD_Dropshipping - Ordering microservice HTTP API"
                });
            });

            IContainer container = BuildContainer(services);

            return new AutofacServiceProvider(container);
         }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json", 
                    "Ordering API v1 swagger endpoint");
            });

            app.UseMvc();
        }


        private IContainer BuildContainer(IServiceCollection services)
        {

            var builder = new ContainerBuilder();

            // Register dotnet core services 
            builder.Populate(services);

            return builder.Build();
        }
    }
}
