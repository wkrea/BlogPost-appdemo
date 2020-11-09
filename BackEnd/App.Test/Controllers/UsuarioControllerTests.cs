using System;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using App.Core.Dominio;
using App.Test.Accesorios;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace App.Test.Controllers
{
    public class UsuarioControllerTests : IntegrationTest
    {
        public UsuarioControllerTests(WebApiFactory fixture) : base(fixture) { }

        [Fact]
        public async Task Get_Puede_Retornar_Usuarios()
        {
            var response = await _client.GetAsync("api/Users");

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var usuarios = JsonConvert.DeserializeObject<Usuario[]>(
                    content
                );

            usuarios.Should().HaveCount(1);
            Assert.IsType<Usuario>(usuarios[0]);
            Assert.Contains("fulano", usuarios[0].Email);
            Assert.Equal(1, usuarios[0].Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public async Task Get_Puede_Retornar_Un_Usuario(int? userId)
        {
            // Arrange - organizar
            Usuario usuario = null;
            Usuario[] usuarios = null;
            string url = userId == null ? "api/Users/" : String.Format("api/Users/{0}", userId);
            var response = await _client.GetAsync(url);

            // Act - actuar
            var content = await response.Content.ReadAsStringAsync();

            if (userId == null)
            {  // Retorna todos los usuarios
                usuarios = JsonConvert.DeserializeObject<Usuario[]>(content);
            }
            else
            {
                usuario = JsonConvert.DeserializeObject<Usuario>(content);
            }

            // assert - afirmar
            if (userId == null)
            {// Retorna todos los usuarios
                usuarios.Should().HaveCount(1);
                Assert.IsType<Usuario>(usuarios[0]);
                Assert.Contains("fulano", usuarios[0].Email);
            }
            else
            {
                Assert.IsType<Usuario>(usuario);
                Assert.Equal(userId, usuario.Id);
            }
        }
    }
}
