using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var builder = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
            //.AddEnvironmentVariables();
            //this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureRepositoryWrapper(this.Configuration);
            services.ConfigureServiceWrapper();

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";
                var urlGIDSAW = "https://www.udi.edu.co/investigaciones/94-grupos-investigacion/gidsaw";
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"API Test - {groupName}",
                    Version = groupName,
                    Description = "API Test - Post and Comments",
                    Contact = new OpenApiContact
                    {
                        Name = "GIDSAW",
                        Email = string.Empty,
                        Url = new Uri(urlGIDSAW),
                    }
                });
            });

            // Enable Cors

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                  builder =>
                  {
                      builder.AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin()
                    ;
                  });
            });

            services.AddMvc();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UDI Web API Demo V1");
            });

            // CORS
            app.UseCors("AllowSpecificOrigin");

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
