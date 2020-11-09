using System;
using System.Net;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Test.Accesorios;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

// https://www.thinktecture.com/en/entity-framework-core/isolation-of-integration-tests-in-2-1/
// https://www.carlrippon.com/testing-ef-core-repositories-with-xunit-and-an-in-memory-db/
// https://www.codeproject.com/Articles/5250190/Integration-Tests-in-ASP-NET-Core-A-DBContext
// https://andrewlock.net/converting-integration-tests-to-net-core-3/
// https://dzone.com/articles/integration-testing-data-access-in-aspnet-core
// https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
// https://blogs.sap.com/2019/12/25/real-time-code-scan-with-sonarlint-following-sonarqube-server-rules-in-visual-studio-codevs-code/
// https://www.thecodebuzz.com/understanding-async-and-await-api-asynchronous-programming/

namespace App.Test.Controllers
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
            
            postitems.Should().HaveCount(2);
            Assert.IsType<PostItem>(postitems[0]);
            Assert.Contains("Fulano", postitems[0].Texto);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public async Task Get_Puede_Retornar_Un_PostItem(int? postId)
        {
            // Arrange - organizar
            PostItem postitem = null;
            PostItem[] postitems = null;
            string url = postId==null ? "api/PostItem/" : String.Format("api/PostItem/{0}", postId);
            var response = await _client.GetAsync(url);

            // Act - actuar
            var content = await response.Content.ReadAsStringAsync();

            if (postId == null){  // Retorna todos los items
                postitems = JsonConvert.DeserializeObject<PostItem[]>(content);
            }
            else
            {
                postitem = JsonConvert.DeserializeObject<PostItem>(content);
            }

            // assert - afirmar
            if (postId == null){// Retorna todos los items
                postitems.Should().HaveCount(2);
                Assert.IsType<PostItem>(postitems[0]);
                Assert.Contains("Fulano", postitems[0].Texto);
            }
            else{
                // postitems.Should().HaveCount(1);
                Assert.IsType<PostItem>(postitem);
                Assert.Equal(postId, postitem.Id);
            }
        }
    }
}