using Xunit;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace App.Test.Accesorios
{
  public abstract class IntegrationTest : IClassFixture<WebApiFactory>
  {
      // private readonly Checkpoint _checkpoint = new Checkpoint
      // {
      //     SchemasToInclude = new[] { "Playground"},
      //     WithReseed = true
      // };

      protected readonly WebApiFactory _factory;
      protected readonly HttpClient _client;
      protected readonly IConfiguration _configuration;

      protected IntegrationTest(WebApiFactory fixture)
      {
          _factory = fixture;
          _client = _factory.CreateClient();
          _configuration = new ConfigurationBuilder()
                .AddJsonFile("integrationsettings.json")
                .Build();

          // _checkpoint.Reset(_configuration.GetConnectionString("SQL")).Wait();
      }
  }
}