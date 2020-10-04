namespace App.Core.Compartido
{
    /// <summary>
    /// Entidad base con atributos comunes para las 
    /// endidades del dominio
    /// </summary>
    public abstract class EntidadBase
    {
        /// <summary>
        /// Atributo para manejar las llaves primarias 
        /// de la tabla con EntityFrameworkCore
        /// </summary>
        public virtual int Id { get; set; }
    }
}
