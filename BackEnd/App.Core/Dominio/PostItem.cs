using System.Collections.Generic;

namespace App.Core.Dominio
{
    /// <summary>
    /// Entidad de dominio 
    /// PostItem
    /// </summary>
    public class PostItem : TextoItem
    {
        public int UserId { get; set; }
        public IList<Comentario> Comentarios { get; set; }
    }
}
