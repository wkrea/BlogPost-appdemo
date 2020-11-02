using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IComentarioRepositorio
    {
        Task GuardarContext();
        Task<IEnumerable<Comentario>> Listar();
        Task Crear(Comentario comentario);
        Task Eliminar(int id);
        Task Editar(Comentario comentario);
        Task<Comentario> BuscarXId(int Id);
        Task<IEnumerable<Comentario>> BuscarPostXId(int postId);
    }
}
