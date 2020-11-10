using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Core.Servicios;
using App.Core.Dominio;
using App.Core.Dominio.Errors;

namespace App.Api.Controllers
{
    [Route("api/Users")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio usersService;

        public UsuarioController(IUsuarioServicio usersService)
        {
            this.usersService = usersService;
        }

        #region  GET
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await this.usersService.GetUsuarios();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this.usersService.GetUsuario(id);
            return Ok(user);
        }
        //#endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> CreateUser(Usuario user)
        {
            await this.usersService.CrearUsuario(user);
            return StatusCode(201);
            // return Ok(new ErrorBase(201));
        }
        #endregion

        // #region PUT
        // #endregion

        // #region DELETE
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePostItem(int id)
        // {
        //     await this.usersService.EliminarUsuario(id);
        //     return Ok();
        // }
#endregion

    }
}

