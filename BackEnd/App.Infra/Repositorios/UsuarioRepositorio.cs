using App.Core.Dominio;
using App.Core.Interfaces;
using App.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private AppDBContext AppDBContext;

        public UsuarioRepositorio(AppDBContext AppDBContext)
        {
            this.AppDBContext = AppDBContext;
        }

        public async Task<IEnumerable<Usuario>> Listar() => await AppDBContext.Usuarios.ToListAsync<Usuario>();

        public void Crear(Usuario postItem)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> BuscarXId(int id)
        {
            return await AppDBContext.Usuarios.FindAsync(id);
        }

        public void Modificar(Usuario postItem)
        {
            throw new NotImplementedException();
        }
    }
}
