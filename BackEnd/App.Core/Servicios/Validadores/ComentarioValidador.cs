using App.Core.Dominio.Errors;
using App.Core.Dominio;
using App.Core.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace App.Core.Servicios.Validadores
{
    /// <summary>
    /// Clase que permite ejercer validaciones sobre 
    /// los atributos de la clase Comentario
    /// Y definir mensajes de error personalizados 
    /// para cada código de error HTTP emitido desde la Api
    /// </summary>
    public class ComentarioValidador : IValidadorServicio<Comentario>
    {
        private readonly IPostItemRepositorio postItemRepository;

        public ComentarioValidador(IPostItemRepositorio postItemRepository)
        {
            this.postItemRepository = postItemRepository;
        }

        public IEnumerable<ErrorBase> Validar(Comentario instancia)
        {
            var ErrorBases = new List<ErrorBase>();

            if (postItemRepository.BuscarXId(instancia.PostId) == null)
            {
                ErrorBases.Add(new ErrorBase(StatusCodes.Status400BadRequest, mensaje:$"No existe PostId"));
            }

            if (string.IsNullOrEmpty(instancia?.Texto))
            {
                ErrorBases.Add(new ErrorBase(StatusCodes.Status400BadRequest, mensaje:$"{nameof(instancia)} no contiene texto"));
            }

            if (instancia.PostId <= 0)
            {
                ErrorBases.Add(new ErrorBase(StatusCodes.Status400BadRequest, mensaje: "PostId no válido"));
            }

            return ErrorBases;
        }
    }
}
