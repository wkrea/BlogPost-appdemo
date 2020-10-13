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
        private AppDBContext _context;

        public ComentarioRepositorio(AppDBContext AppDBContext)
        {
            this._context = AppDBContext;
        }
        public async Task GuardarContext(){
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Comentario> Listar => throw new NotImplementedException();
        public Comentario BuscarXId(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task Crear(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
        }
        public async Task Editar(Comentario comentario)
        {
            _context.Entry(comentario).State = EntityState.Modified;
            await this.GuardarContext();
            
        }
        public async Task Eliminar(int id)
        {
            Comentario item = await _context.Comentarios.FindAsync(id);
            if(item != null){
                _context.Comentarios.Remove(item);
                await this.GuardarContext();
            }
        }
        public async Task<IEnumerable<Comentario>> BuscarPostXId(int postId)
        {
            return await _context
                 .Comentarios
                 .Where(x => x.PostId == postId)
                 .ToListAsync();
        }
    }
}
