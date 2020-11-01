using App.Core.Dominio.Errors;
using System.Collections.Generic;

namespace App.Core.Servicios.Validadores
{
    /// <summary>
    /// Interfaz para definir el comportamiento y funcionalidades
    /// de cualquier validador personalizado de un servicio
    /// utilizado por la Api
    /// </summary>
    /// <typeparam name="T">Tipo del validador</typeparam>
    public interface IValidadorServicio<T>
    {
        IEnumerable<ErrorBase> Validar(T instancia);
    }
}