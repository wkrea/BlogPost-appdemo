using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using App.Core.Servicios.Validadores;
using Microsoft.AspNetCore.Http;

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

        public async Task<IEnumerable<PostItem>> ListarPostsItems()
        {
            return await this.postItemRepositorio.Listar();
        }
        public async Task<PostItem> GetPostItemById(int id)
        {
            return await this.postItemRepositorio.BuscarXId(id);;
        }
        public async Task<IEnumerable<ErrorBase>> CrearPostItem(PostItem postItem)
        {
            postItem.CreadoFecha = DateTime.Now;

            List<ErrorBase> errores = null;
            try
            {
                errores.AddRange(this.postValidator.Validar(postItem));
                await postItemRepositorio.Crear(postItem);
            }
            catch
            {
                errores.Add(new ErrorBase(StatusCodes.Status500InternalServerError));
            }
            return errores;
        }

        public async Task<IEnumerable<ErrorBase>> EditarPostItem(PostItem postItem)
        {
            postItem.ModificadoFecha = DateTime.Now;

            List<ErrorBase> errores = null;
            try
            {
                errores.AddRange(this.postValidator.Validar(postItem));
                await this.postItemRepositorio.Editar(postItem);
            }
            catch
            {
                errores.Add(new ErrorBase(StatusCodes.Status500InternalServerError));
            }
            return errores;
        }

        public async Task<IEnumerable<ErrorBase>> EliminarPostItem(PostItem postItem)
        {
            List<ErrorBase> errores = null;
            try
            {
                errores.AddRange(this.postValidator.Validar(postItem));
                await this.postItemRepositorio.Eliminar(postItem);
            }
            catch
            {
                errores.Add(new ErrorBase(StatusCodes.Status500InternalServerError));
            }
            return errores;
        }

        public async Task<IEnumerable<ErrorBase>> CrearComentario(Comentario comentario)
        {
            comentario.CreadoFecha = DateTime.Now;
            List<ErrorBase> errores = null;
            try
            {
                errores.AddRange(this.comentarioValidator.Validar(comentario));
                await this.comentarioRepositorio.Editar(comentario);
            }
            catch
            {
                errores.Add(new ErrorBase(StatusCodes.Status500InternalServerError));
            }
            return errores;
        }
        public Task<IEnumerable<Comentario>> GetComentariosByPostItemId(int postId)
        {
            return this.comentarioRepositorio.BuscarPostXId(postId);
        }
    }
}
