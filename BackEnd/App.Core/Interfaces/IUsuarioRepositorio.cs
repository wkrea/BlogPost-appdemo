using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task GuardarContext();
        Task<IEnumerable<Usuario>> Listar(); //{ get; }
        Task Crear(Usuario postItem);
        Task Eliminar(int id);
        Task Editar(Usuario postItem);
        Task<Usuario> BuscarXId(int Id);
    }
}
