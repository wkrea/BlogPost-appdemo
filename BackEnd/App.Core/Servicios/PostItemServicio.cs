using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using App.Core.Servicios.Validadores;

namespace App.Core.Servicios
{
    public class PostItemServicio : IPostItemServicio
    {
        private IPostItemRepositorio postItemRepositorio;
        private IComentarioRepositorio comentarioRepositorio;
        private PostValidador postValidator;
        private ComentarioValidador comentarioValidator;

        public PostItemServicio(
            IPostItemRepositorio postItemRepo,
            IComentarioRepositorio comentarioRepo,
            PostValidador postValidator,
            ComentarioValidador comentarioValidator)
        {
            this.postItemRepositorio = postItemRepo;
            this.comentarioRepositorio = comentarioRepo;
            this.postValidator = postValidator;
            this.comentarioValidator = comentarioValidator;
        }

        public async Task<IEnumerable<ErrorApp>> CrearComentario(Comentario comentario)
        {
            comentario.CreadoFecha = DateTime.Now;
            var errors = this.comentarioValidator.Validar(comentario);
            await this.comentarioRepositorio.Crear(comentario);
            return errors;
        }

        public async Task<IEnumerable<ErrorApp>> CrearPostItem(PostItem postItem)
        {
            postItem.CreadoFecha = DateTime.Now;
            var errors = this.postValidator.Validar(postItem);
            await postItemRepositorio.Crear(postItem);
            return errors;
        }

        public Task EliminarPostItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostItem>> ListarPostsItems()
        {
            return await this.postItemRepositorio.Listar();
        }

        public Task<IEnumerable<Comentario>> GetComentariosByPostItemId(int postId)
        {
            return this.comentarioRepositorio.BuscarPostXId(postId);
        }

        public async Task<IEnumerable<ErrorApp>> EditarPostItem(PostItem postItem)
        {
            postItem.ModificadoFecha = DateTime.Now;

            List<ErrorApp> errores = null;
            try
            {
                errores.AddRange(this.postValidator.Validar(postItem));
                await this.postItemRepositorio.Editar(postItem);
            }
            catch
            {
                errores.Add(new ErrorApp { Mensaje = "Ocurrió un error del dato del servidor" });
            }
            return errores;
        }

        public async Task<bool> GetPostItemById(int id)
        {
            return await this.postItemRepositorio.postExiste(id);
        }
    }
}
