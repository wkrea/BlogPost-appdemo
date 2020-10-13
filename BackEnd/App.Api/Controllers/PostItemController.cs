using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Core.Dominio.Errors;
using App.Core.DTO;
using App.Core.DTO.Command;
using App.Core.Servicios;
using App.Core.Dominio;

namespace App.Api.Controllers
{
    [Route("api/PostItem")]
    public class PostItemController : ControllerBase
    {
        private IPostItemServicio postItemService;

        public PostItemController(IPostItemServicio postItemService)
        {
            this.postItemService = postItemService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(IEnumerable<ErrorApp>))]
        public async Task<IActionResult> PostItemAsync(PostItemDTO postItem)
        {
            var _postItem = postItem.ADominio();

            var result = await this.postItemService.CrearPostItem(_postItem);

            if (result.Count() > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("{id}/comentario")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(IEnumerable<ErrorApp>))]
        public async Task<IActionResult> Comment(ComentarioDTO comentario, int id)
        {
            var _comment = comentario.ADominio();
            _comment.PostId = id;
            var result = await this.postItemService.CrearComentario(_comment);

            if (result.Count() > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostItem(int id)
        {
            await this.postItemService.EliminarPostItem(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(IEnumerable<ErrorApp>))]
        public async Task<IActionResult> UpdatePostItem(int id, PostItem postItem)
        {
            if (postItem.Id != id)
            {
                BadRequest();
            }

            var existe = await this.postItemService.GetPostItemById(id);
            if (existe == null)
            {
                NotFound();
            }
            else
            {
                var result = await this.postItemService.EditarPostItem(postItem);
                if (result.Count() > 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}/comentarios")]
        [ProducesResponseType(200, Type = typeof(IList<Comentario>))]
        public async Task<IActionResult> GetComments(int id)
        {
            var comments = await this.postItemService.GetComentariosByPostItemId(id);
            return Ok(comments);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<PostItem>))]
        public async Task<IActionResult> GetAllPostsItems()
        {
            var postItem = await this.postItemService.ListarPostsItems();
            return Ok(postItem);
        }
    }
}
