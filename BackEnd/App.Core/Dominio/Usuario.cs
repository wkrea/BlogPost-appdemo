using App.Core.Compartido;

namespace App.Core.Dominio
{
    /// <summary>
    /// Entidad de dominio 
    /// Usuario
    /// </summary>
    public class Usuario : EntidadBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
