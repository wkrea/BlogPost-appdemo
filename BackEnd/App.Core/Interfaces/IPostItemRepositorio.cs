﻿using App.Core.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IPostItemRepositorio
    {
        Task GuardarContext();
        Task<IEnumerable<PostItem>> Listar();
        Task Crear(PostItem postItem);
        Task Eliminar(PostItem postItem);
        Task Editar(PostItem postItem);
        Task<PostItem> BuscarXId(int Id);
        Task<bool> postExiste(int id);
    }
}
