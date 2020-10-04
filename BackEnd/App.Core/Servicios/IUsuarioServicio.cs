using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Servicios
{
    public interface IUsuarioServicio
    {
        Task CrearUsuario(Usuario user);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
    }
}
