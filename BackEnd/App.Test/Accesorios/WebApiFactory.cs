using App.Core.Servicios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace App.Test.Accesorios
{
  public class WebApiFactory : WebApplicationFactory<App.Api.Startup> 
  {
        public ITestOutputHelper testOutput { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureAppConfiguration(conf =>
            {
                var integrationConf = new ConfigurationBuilder()
                                          .AddJsonFile("integrationsettings.json")
                                          .Build();

                conf.AddConfiguration(integrationConf);

            });
            // 
            //builder.ConfigureLogging(logging =>
            //{
            //    logging.Services.Clear(); // ClearProviders();
            //    logging.Services.AddXUnit(testOutput);
            //    logging.AddXUnit(testOutput);

            //});

            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IPostItemServicio, PostServiceStub>();
            });
        }
    }
}