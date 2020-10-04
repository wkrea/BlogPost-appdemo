using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using App.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infra.Repositorios
{
    public class PostItemRepositorio : IPostItemRepositorio
    {
        private AppDBContext _context;

        public PostItemRepositorio(AppDBContext AppDBContext)
        {
            this._context = AppDBContext;
        }

        public async Task<IEnumerable<PostItem>> Listar()
        {
            return await _context.PostItems.AsNoTracking().ToListAsync();
        }

        public async Task Crear(PostItem postItem)
        {
            _context.PostItems.Add(postItem);
            await _context.SaveChangesAsync();
        }

        public async Task Editar(PostItem postItem)
        {
            _context.Entry(postItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public async Task Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public PostItem BuscarXId(int id) => _context.Find<PostItem>(id);


        public async Task<bool> postExiste(int id)
        {
            return await _context.PostItems
                          .AnyAsync(post => post.Id == id);
        }
    }
}
