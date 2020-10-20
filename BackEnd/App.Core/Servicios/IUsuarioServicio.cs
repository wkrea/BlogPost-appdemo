using App.Core.Dominio;
using App.Core.Dominio.Errors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Servicios
{
    public interface IUsuarioServicio
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<IEnumerable<ErrorBase>> CrearUsuario(Usuario user);
        Task<IEnumerable<ErrorBase>> EditarUsuario(Usuario user);
        Task EliminarUsuario(int id);
    }
}
