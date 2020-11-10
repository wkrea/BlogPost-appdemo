using System;
using System.Net;
using System.Net.Http;
using System.Text;
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

        /// <summary>
        /// https://carldesouza.com/httpclient-getasync-postasync-sendasync-c/
        /// https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task POST_Puede_Crear_Usuarios()
        {
            Uri u = new Uri("http://localhost:5000/api/Users");
            Usuario nuevoUsuario = new Usuario { UserName = "usuarioPrueba", Email = "usuarioPrueba@gmail.com" };
            // var payload = "{\"Email\": \"usuarioPrueba@gmail.com\"}";
            // System.Text.Json; --> Microsoft
            // string payload = JsonSerializer.Serialize(nuevoUsuario);
            // Newtonsoft.Json; --> Newtonsoft
            string payload = JsonConvert.SerializeObject(nuevoUsuario);

            HttpContent sendContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Users", sendContent);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("Created", response.StatusCode.ToString());
            Assert.Equal(201, (int)response.StatusCode);

            // response.StatusCode.Should().Be(HttpStatusCode.OK);
            // System.Text.Json; --> Microsoft
            // var resultado = JsonSerializer.Deserialize<ErrorBase>(content);
            // Newtonsoft.Json; --> Newtonsoft
            // var usuarios = JsonConvert.DeserializeObject<Usuario[]>(content);

            // Assert.IsType<ErrorBase>(resultado);
            // Assert.Contains("creado", resultado.Mensaje);
            // Assert.Equal(resultado.StatusCode, (int)HttpStatusCode.Created); //201
        }
    }
}
