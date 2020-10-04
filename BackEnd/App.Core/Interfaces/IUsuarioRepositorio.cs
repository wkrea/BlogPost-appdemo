using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> Listar(); //{ get; }
        void Crear(Usuario postItem);
        void Eliminar(int id);
        void Modificar(Usuario postItem);
        Task<Usuario> BuscarXId(int Id);
    }
}
