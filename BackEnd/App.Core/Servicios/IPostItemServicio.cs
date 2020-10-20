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
        Task<IEnumerable<ErrorBase>> CrearPostItem(PostItem postItem);
        Task<IEnumerable<ErrorBase>> EditarPostItem(PostItem postItem);
        Task<IEnumerable<ErrorBase>> EliminarPostItem(PostItem postItem);

        #region cruce PostItem-->Comentarios
        Task<IEnumerable<ErrorBase>> CrearComentario(Comentario comment);
        Task<IEnumerable<Comentario>> GetComentariosByPostItemId(int postId);
        #endregion
    }
}
