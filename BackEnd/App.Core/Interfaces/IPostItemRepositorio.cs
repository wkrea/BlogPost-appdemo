using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IPostItemRepositorio
    {
        Task<IEnumerable<PostItem>> Listar();
        Task Crear(PostItem postItem);
        Task Eliminar(int id);
        Task Editar(PostItem postItem);
        PostItem BuscarXId(int Id);
        Task<bool> postExiste(int id);
    }
}
