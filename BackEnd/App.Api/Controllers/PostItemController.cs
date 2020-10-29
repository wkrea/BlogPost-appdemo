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

        #region  GET
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<PostItem>))]
        public async Task<IActionResult> GetAllPostsItems()
        {
            var postItem = await this.postItemService.ListarPostsItems();
            return Ok(postItem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IList<PostItem>))]
        public async Task<IActionResult> GetPostsItem(int id)
        {
            var postItem = await this.postItemService.GetPostItemById(id);
            if (postItem == null)
            {
                return NotFound(new ErrorBase(404, $"Post con id {id} no fue encontrado"));
            }   
            return Ok(postItem);
        }

        // [HttpGet("{id}/comentarios")]
        // [ProducesResponseType(200, Type = typeof(IList<Comentario>))]
        // public async Task<IActionResult> GetComments(int id)
        // {
        //     var comments = await this.postItemService.GetComentariosByPostItemId(id);
        //     if (comments == null)
        //     {
        //         return NotFound(new ErrorBase(404, $"Comentario con id {id} no fue encontrado"));
        //     }  
        //     return Ok(comments);
        // }
        // #endregion

        // #region POST
        // [HttpPost]
        // [ProducesResponseType(201)]
        // [ProducesResponseType(400, Type = typeof(IEnumerable<ErrorBase>))]
        // public async Task<IActionResult> PostItemAsync(PostItemDTO postItem)
        // {
        //     if(!ModelState.IsValid) return BadRequest(new ApiBadRequestResponse(ModelState));

        //     var _postItem = postItem.ADominio();

        //     var errores = await this.postItemService.CrearPostItem(_postItem);

        //     if (errores.Count() > 0)
        //     {
        //         // BadRequest(new ErrorBase(400, errores));
        //         return StatusCode(StatusCodes.Status400BadRequest, errores);
        //     }
        //     return StatusCode(StatusCodes.Status201Created);
        //     // return CreatedAtAction("GetPostsItem", new {id=_postItem.Id}, postItem);
        // }

        // [HttpPost("{id}/comentario")]
        // [ProducesResponseType(201)]
        // [ProducesResponseType(400, Type = typeof(IEnumerable<ErrorBase>))]
        // public async Task<IActionResult> Comment(ComentarioDTO comentario, int id)
        // {
        //     var _comment = comentario.ADominio();
        //     _comment.PostId = id;
        //     var result = await this.postItemService.CrearComentario(_comment);

        //     if (result.Count() > 0)
        //     {
        //         return StatusCode(StatusCodes.Status400BadRequest, result);
        //     }

        //     return StatusCode(StatusCodes.Status201Created);
        //     // return CreatedAtAction("GetComments", new {id=_comment.PostId}, _comment);
        // }
        // #endregion

        // #region PUT
        // [HttpPut("{id}")]
        // [ProducesResponseType(201)]
        // [ProducesResponseType(400, Type = typeof(IEnumerable<ErrorBase>))]
        // public async Task<IActionResult> UpdatePostItem(int id, PostItem postItem)
        // {
        //     if (postItem.Id != id)
        //     {
        //         BadRequest();
        //     }

        //     var existe = await this.postItemService.GetPostItemById(id);
        //     if (existe == null)
        //     {
        //         NotFound();
        //     }
        //     else
        //     {
        //         var result = await this.postItemService.EditarPostItem(postItem);
        //         if (result.Count() > 0)
        //         {
        //             return StatusCode(StatusCodes.Status400BadRequest, result);
        //         }
        //     }
        //     return StatusCode(StatusCodes.Status202Accepted);
        // }
        // #endregion

        // #region DELETE
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePostItem(int id)
        // {
        //     var existe = await this.postItemService.GetPostItemById(id);
        //     if (existe == null)
        //     {
        //         NotFound();
        //     }
        //     else
        //     {
        //         var result = await this.postItemService.EliminarPostItem(existe);
        //         if (result.Count() > 0)
        //         {
        //             return StatusCode(StatusCodes.Status400BadRequest, result);
        //         }
        //     }
        //     return StatusCode(StatusCodes.Status200OK);
        // }
        #endregion
    }
}
