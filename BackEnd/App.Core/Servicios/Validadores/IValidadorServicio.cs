using App.Core.Dominio.Errors;
using System.Collections.Generic;

namespace App.Core.Servicios.Validadores
{
    public interface IValidadorServicio<T>
    {
        IEnumerable<ErrorApp> Validar(T entity);
    }
}