using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Core.Interfaces;

namespace App.Core.Servicios
{
    public class UsuariosServicio : IUsuarioServicio
    {
        private IUsuarioRepositorio _contexto;

        public UsuariosServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _contexto = usuarioRepositorio;
        }
        public Task CrearUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var lisUsuarios = await _contexto.Listar();
            return lisUsuarios;
        }

        public Task<Usuario> GetUsuario(int id)
        {
            var usuario = _contexto.BuscarXId(id);
            return usuario;
        }
    }
}
