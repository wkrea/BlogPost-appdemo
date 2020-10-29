using System.Net;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Test.Accesorios;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

// https://andrewlock.net/converting-integration-tests-to-net-core-3/

namespace App.Test
{
    public class PostItemControllerTests : IntegrationTest
    {
        public PostItemControllerTests(WebApiFactory factory) : base(factory) { }

        [Fact]
        public async Task Get_Puede_Retornar_PostItems()
        {
            var response = await _client.GetAsync("api/PostItem");

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var postitems = JsonConvert.DeserializeObject<PostItem[]>(
                  content
                );
            
            postitems.Should().HaveCount(1);
            Assert.IsType<PostItem>(postitems[0]);
            Assert.Contains("PostItem", postitems[0].Texto);
        }
    }
}