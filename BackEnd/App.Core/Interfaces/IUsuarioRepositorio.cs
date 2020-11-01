using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task GuardarContext();
        Task<IEnumerable<Usuario>> Listar();
        Task Crear(Usuario usuario);
        Task Eliminar(int id);
        Task Editar(Usuario usuario);
        Task<Usuario> BuscarXId(int Id);
    }
}
