using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Core.Interfaces;
using App.Core.Dominio.Errors;

namespace App.Core.Servicios
{
    public class UsuariosServicio : IUsuarioServicio
    {
        private IUsuarioRepositorio _userRepo;

        public UsuariosServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _userRepo = usuarioRepositorio;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var lisUsuarios = await _userRepo.Listar();
            return lisUsuarios;
        }
        public Task<Usuario> GetUsuario(int id)
        {
            var usuario = _userRepo.BuscarXId(id);
            return usuario;
        }
        public async Task<IEnumerable<ErrorApp>> CrearUsuario(Usuario usuario)
        {
            List<ErrorApp> errores = null;
            try
            {
                await _userRepo.Crear(usuario);
            }
            catch
            {
                errores.Add(new ErrorApp { Mensaje = "Ocurrió un error al guardar el dato en el servidor" });
            }
            return errores;
        }

        public async Task<IEnumerable<ErrorApp>> EditarUsuario(Usuario user)
        {
            List<ErrorApp> errores = null;
            try
            {
                await this._userRepo.Editar(user);
            }
            catch
            {
                errores.Add(new ErrorApp { Mensaje = "Ocurrió un error al guardar el dato en el servidor" });
            }
            return errores;
        }
        public async Task EliminarUsuario(int id)
        {
            await _userRepo.Eliminar(id);
        }
    }
}
