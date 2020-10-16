using App.Core.Dominio;
using App.Core.Dominio.Errors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Servicios
{
    public interface IPostItemServicio
    {
        Task<IEnumerable<PostItem>> ListarPostsItems();
        Task<PostItem> GetPostItemById(int id);
        Task<IEnumerable<ErrorApp>> CrearPostItem(PostItem postItem);
        Task<IEnumerable<ErrorApp>> EditarPostItem(PostItem postItem);
        Task EliminarPostItem(int id);

        #region cruce PostItem-->Comentarios
        Task<IEnumerable<ErrorApp>> CrearComentario(Comentario comment);
        Task<IEnumerable<Comentario>> GetComentariosByPostItemId(int postId);
        #endregion
    }
}
