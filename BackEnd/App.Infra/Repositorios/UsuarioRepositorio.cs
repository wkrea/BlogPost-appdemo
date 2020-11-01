using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

using App.Core.Dominio;
using App.Core.Interfaces;
using App.Infra.Contexto;
namespace App.Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDBContext _context;
        public UsuarioRepositorio(AppDBContext AppDBContext)
        {
            this._context = AppDBContext;
        }
        public async Task GuardarContext(){
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Usuario>> Listar() => await _context.Usuarios.ToListAsync<Usuario>();

        public async Task<Usuario> BuscarXId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await this.GuardarContext();
        }
        public async Task Editar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await this.GuardarContext();
        }
        public async Task Eliminar(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
            if(usuario != null){
                _context.Usuarios.Remove(usuario);
                await this.GuardarContext();
            }
        }
    }
}
