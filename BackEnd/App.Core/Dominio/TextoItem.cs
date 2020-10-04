using App.Core.Compartido;
using System;

namespace App.Core.Dominio
{
    /// <summary>
    /// Entidad Abstracta de dominio 
    /// TextoItem
    /// Refleja el uso de Herencia tipo has-a (tiene un)
    /// permitiendo desacoplamiento
    /// </summary>
    public abstract class TextoItem : EntidadBase
    {
        public string Texto { get; set; }
        public DateTime CreadoFecha { get; set; }
        public DateTime? ModificadoFecha { get; set; }
    }
}
