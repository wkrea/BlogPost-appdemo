﻿using App.Core.Dominio;
using App.Core.Dominio.Errors;
using App.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace App.Core.Servicios.Validadores
{
    /// <summary>
    /// Clase que permite ejercer validaciones sobre 
    /// los atributos de la clase PostItem
    /// Y definir mensajes de error personalizados 
    /// para cada código de error HTTP emitido desde la Api
    /// </summary>
    public class PostValidador : IValidadorServicio<PostItem>
    {
        private IUsuarioRepositorio userRepository;

        public PostValidador(IUsuarioRepositorio userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<ErrorBase> Validar(PostItem postItem)
        {
            var ErrorBases = new List<ErrorBase>();

            var existeUsuario = userRepository.BuscarXId(postItem.UserId);
            if (existeUsuario.Result == null)
            {
                ErrorBases.Add(new ErrorBase(StatusCodes.Status400BadRequest, mensaje:$"No existe UserId"));
            }

            if (string.IsNullOrEmpty(postItem?.Texto))
            {
                ErrorBases.Add(new ErrorBase(StatusCodes.Status400BadRequest, mensaje:$"postItem no contiene text"));
            }

            if (postItem.UserId <= 0)
            {
                ErrorBases.Add(new ErrorBase(StatusCodes.Status400BadRequest, mensaje:"Usuario no Valido"));
            }

            return ErrorBases;
        }
    }
}
