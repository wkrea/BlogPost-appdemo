using System.Data.Common;
using App.Core.Dominio;
using App.Core.Interfaces;
using App.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infra.Repositorios
{
    public class PostItemRepositorio : IPostItemRepositorio
    {
        private readonly AppDBContext _context;

        public PostItemRepositorio(AppDBContext AppDBContext)
        {
            this._context = AppDBContext;
        }
        public async Task GuardarContext()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PostItem>> Listar()
        {
            return await _context.PostItems.AsNoTracking().ToListAsync();
        }

        public async Task Crear(PostItem postItem)
        {
            _context.PostItems.Add(postItem);
            await this.GuardarContext();
        }

        public async Task Editar(PostItem postItem)
        {
            _context.Entry(postItem).State = EntityState.Modified;
            await this.GuardarContext();
        }

        public async Task Eliminar(PostItem postItem)
        {
            _context.PostItems.Remove(postItem);
            await this.GuardarContext();
        }

        public async Task<PostItem> BuscarXId(int id) => await _context.FindAsync<PostItem>(id);

        public async Task<bool> postExiste(int id)
        {
            return await _context.PostItems
                          .AnyAsync(post => post.Id == id);
        }
    }
}
