using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Servicios;

namespace App.Test.Accesorios
{
  public class PostServiceStub : IPostItemServicio
  {
    public async Task<IEnumerable<PostItem>> ListarPostsItems()
    {
            List<PostItem> posts = new List<PostItem>();
            var post = new PostItem { Id = 1, UserId = 1, Texto = "PostItem1 User1" };
            posts.Add(post);
            return posts;
    }

    public Task<PostItem> GetPostItemById(int id)
    {
      throw new System.NotImplementedException();
    }
    public Task<IEnumerable<Comentario>> GetComentariosByPostItemId(int postId)
    {
      throw new System.NotImplementedException();
    }
    
    public Task<IEnumerable<ErrorBase>> CrearComentario(Comentario comment)
    {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<ErrorBase>> CrearPostItem(PostItem postItem)
    {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<ErrorBase>> EditarPostItem(PostItem postItem)
    {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<ErrorBase>> EliminarPostItem(PostItem postItem)
    {
      throw new System.NotImplementedException();
    }

    
  }
}