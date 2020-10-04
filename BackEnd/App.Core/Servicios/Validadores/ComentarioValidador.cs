using App.Core.Dominio.Errors;
using App.Core.Dominio;
using App.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Servicios.Validadores
{
    public class ComentarioValidador : IValidadorServicio<Comentario>
    {
        private IPostItemRepositorio postItemRepository;

        public ComentarioValidador(IPostItemRepositorio postItemRepository)
        {
            this.postItemRepository = postItemRepository;
        }

        public IEnumerable<ErrorApp> Validar(Comentario comentario)
        {
            var ErrorApps = new List<ErrorApp>();

            if (postItemRepository.BuscarXId(comentario.PostId) == null)
            {
                ErrorApps.Add(new ErrorApp { Mensaje = $"No existe PostId" });
            }

            if (string.IsNullOrEmpty(comentario?.Texto))
            {
                ErrorApps.Add(new ErrorApp { Mensaje = $"{nameof(comentario)} no contiene texto" });
            }

            if (comentario.PostId <= 0)
            {
                ErrorApps.Add(new ErrorApp { Mensaje = "PostId no válido" });
            }

            return ErrorApps;
        }
    }
}
