using App.Core.Dominio;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Contexto
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated(); // Just for test
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}