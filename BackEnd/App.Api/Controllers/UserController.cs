using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Core.Dominio;
using App.Core.Servicios;

namespace App.Api.Controllers
{
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private IUsuarioServicio usersService;

        public UsersController(IUsuarioServicio usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(Usuario user)
        {
            await this.usersService.CrearUsuario(user);
            return StatusCode(201);
        }

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
    }
}

