using System.Data.Common;
using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using App.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
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
        public async Task GuardarContext()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
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

        public async Task Eliminar(int id)
        {
            PostItem item = await _context.PostItems.FindAsync(id);
            if(item != null){
                _context.PostItems.Remove(item);
                await this.GuardarContext();
            }
        }

        public async Task<PostItem> BuscarXId(int id) => await _context.FindAsync<PostItem>(id);

        public async Task<bool> postExiste(int id)
        {
            return await _context.PostItems
                          .AnyAsync(post => post.Id == id);
        }
    }
}
