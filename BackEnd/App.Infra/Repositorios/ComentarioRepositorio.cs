using System.Data.Common;
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
        private AppDBContext _contexto;

        public ComentarioRepositorio(AppDBContext AppDBContext)
        {
            this._contexto = AppDBContext;
        }
        public async Task GuardarContext(){
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<Comentario>> Listar() => await _contexto.Comentarios.AsNoTracking().ToListAsync();
        public async Task<Comentario> BuscarXId(int id)
        {
            return await _contexto.Comentarios.FirstOrDefaultAsync(c=> c.Id.Equals(id));
        }
        public async Task<IEnumerable<Comentario>> BuscarPostXId(int postId)
        {
            var results = await _contexto.Comentarios.ToListAsync();

            return results.Where(x => x.PostId == postId).ToList();
        }
        public async Task Crear(Comentario comentario)
        {
            _contexto.Comentarios.Add(comentario);
            await _contexto.SaveChangesAsync();
        }
        public async Task Editar(Comentario comentario)
        {
            _contexto.Entry(comentario).State = EntityState.Modified;
            await this.GuardarContext();
        }
        public async Task Eliminar(int id)
        {
            Comentario item = await _contexto.Comentarios.FindAsync(id);
            if(item != null){
                _contexto.Comentarios.Remove(item);
                await this.GuardarContext();
            }
        }
    }
}
