using App.Core.Dominio;
using App.Core.Dominio.Errors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Servicios
{
    public interface IPostItemServicio
    {
        Task<IEnumerable<ErrorApp>> CrearPostItem(PostItem postItem);
        Task<IEnumerable<ErrorApp>> CrearComentario(Comentario comment);
        Task<bool> GetPostItemById(int id);
        Task EliminarPostItem(int id);
        Task<IEnumerable<ErrorApp>> EditarPostItem(PostItem postItem);
        Task<IEnumerable<Comentario>> GetComentariosByPostItemId(int postId);
        Task<IEnumerable<PostItem>> ListarPostsItems();
    }
}
