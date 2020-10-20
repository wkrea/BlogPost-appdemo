using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Dominio;
using App.Core.Interfaces;
using App.Core.Dominio.Errors;
using Microsoft.AspNetCore.Http;

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
        public async Task<IEnumerable<ErrorBase>> CrearUsuario(Usuario usuario)
        {
            List<ErrorBase> errores = new List<ErrorBase>();
            try
            {
                await _userRepo.Crear(usuario);
            }
            catch
            {
                errores.Add(new ErrorBase(StatusCodes.Status500InternalServerError));
            }
            return errores;
        }

        public async Task<IEnumerable<ErrorBase>> EditarUsuario(Usuario user)
        {
            List<ErrorBase> errores = new List<ErrorBase>();
            try
            {
                await this._userRepo.Editar(user);
            }
            catch
            {
                errores.Add(new ErrorBase(StatusCodes.Status500InternalServerError));
            }
            return errores;
        }
        public async Task EliminarUsuario(int id)
        {
            await _userRepo.Eliminar(id);
        }
    }
}
