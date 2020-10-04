namespace App.Core.DTO.Command
{
    /// <summary>
    /// Objeto de transferencia de información para
    /// la entidad PostItem
    /// </summary>
    public class PostItemDTO
    {
        public int UserId { get; set; }
        public string Texto { get; set; }
    }
}
