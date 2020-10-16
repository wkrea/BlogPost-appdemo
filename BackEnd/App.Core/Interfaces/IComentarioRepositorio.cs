using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IComentarioRepositorio
    {
        Task GuardarContext();
        Task<IEnumerable<Comentario>> Listar();
        Task Crear(Comentario comment);
        Task Eliminar(int id);
        Task Editar(Comentario comment);
        Task<Comentario> BuscarXId(int Id);
        Task<IEnumerable<Comentario>> BuscarPostXId(int postId);
    }
}
