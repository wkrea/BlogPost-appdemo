using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using App.Core.Dominio;
using App.Core.Interfaces;
using App.Infra.Contexto;

namespace App.Infra.Repositorios
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private AppDBContext AppDBContext;

        public ComentarioRepositorio(AppDBContext AppDBContext)
        {
            this.AppDBContext = AppDBContext;
        }

        public IEnumerable<Comentario> Listar => throw new NotImplementedException();

        public async Task Crear(Comentario comentario)
        {
            AppDBContext.Comentarios.Add(comentario);
            await AppDBContext.SaveChangesAsync();
        }

        public async Task Editar(Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public async Task Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Comentario BuscarXId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comentario>> BuscarPostXId(int postId)
        {
            return await AppDBContext
                 .Comentarios
                 .Where(x => x.PostId == postId)
                 .ToListAsync();
        }

    }
}
