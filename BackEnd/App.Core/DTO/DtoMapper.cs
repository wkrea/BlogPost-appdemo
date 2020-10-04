using App.Core.Dominio;
using App.Core.DTO.Command;

namespace App.Core.DTO
{
    public static class DtoMapper
    {
        /// <summary>
        /// Mapear hacia objeto de dominio
        /// </summary>
        /// <param name="postItemDTO"></param>
        /// <returns></returns>
        public static PostItem ADominio(this PostItemDTO postItemDTO)
        {
            return new PostItem { Texto = postItemDTO.Texto, UserId = postItemDTO.UserId };
        }
        /// <summary>
        /// Mapear hacia objeto de dominio
        /// </summary>
        /// <param name="commentDTO"></param>
        /// <returns></returns>
        public static Comentario ADominio(this ComentarioDTO comentarioDTO)
        {
            return new Comentario { Texto = comentarioDTO.Texto };
        }
    }
}
