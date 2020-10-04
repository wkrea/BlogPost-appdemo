using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using System.Collections.Generic;

namespace App.Core.Servicios.Validadores
{
    public class PostValidador : IValidadorServicio<PostItem>
    {
        private IUsuarioRepositorio userRepository;

        public PostValidador(IUsuarioRepositorio userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<ErrorApp> Validar(PostItem postItem)
        {
            var ErrorApps = new List<ErrorApp>();

            var existeUsuario = userRepository.BuscarXId(postItem.UserId);
            if (existeUsuario.Result == null)
            {
                ErrorApps.Add(new ErrorApp { Mensaje= $"No existe UserId" });
            }

            if (string.IsNullOrEmpty(postItem?.Texto))
            {
                ErrorApps.Add(new ErrorApp { Mensaje = $"postItem no contiene text" });
            }

            if (postItem.UserId <= 0)
            {
                ErrorApps.Add(new ErrorApp { Mensaje = "Usuario no Valido" });
            }

            return ErrorApps;
        }
    }
}
