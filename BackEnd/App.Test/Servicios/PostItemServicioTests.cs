using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using App.Core.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Test.Servicios
{
    [TestClass]
    public class PostItemServicioTests
    {
        private readonly IPostItemServicio postItemSrvTest;

        private readonly Mock<IUsuarioRepositorio> usuarioRepoTest;
        private readonly Mock<IPostItemRepositorio> postItemRepoTest;
        private readonly Mock<IComentarioRepositorio> comentarioRepoTest;

        public PostItemServicioTests()
        {
            this.usuarioRepoTest = new Mock<IUsuarioRepositorio>();
            this.postItemRepoTest = new Mock<IPostItemRepositorio>();
            this.comentarioRepoTest = new Mock<IComentarioRepositorio>();

            this.usuarioRepoTest
                .Setup(x => x.BuscarXId(1))
                .ReturnsAsync(new Core.Dominio.Usuario { Email = "fulano@gmail.com", Id = 1, UserName = "fulano" });

            this.postItemSrvTest = new PostItemServicio(
                postItemRepoTest.Object,
                comentarioRepoTest.Object,
                new Core.Servicios.Validadores.PostValidador(this.usuarioRepoTest.Object),
                new Core.Servicios.Validadores.ComentarioValidador(this.postItemRepoTest.Object));
        }

        [TestMethod]
        public async Task Creando_PostItemAsync()
        {
            // Arrange
            var postItem = new Core.Dominio.PostItem { Texto = "Texto de Post Prueba", UserId = 1 };

            // Act
            IEnumerable<ErrorBase> response = await this.postItemSrvTest.CrearPostItem(postItem);

            // Assert
            Assert.IsTrue(response.Count().Equals(0));
        }

        [TestMethod]
        public async Task Intruso_Creando_PostItemAsync()
        {
            // Arrange
            var postItem = new Core.Dominio.PostItem { Texto = "Texto de un usuario no registrado", UserId = 2 };

            // Act
            var response = await this.postItemSrvTest.CrearPostItem(postItem);

            // Assert
            Assert.IsTrue(!response.Count().Equals(0));
            // Assert.IsTrue(val);
        }
    }
}
