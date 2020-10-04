using App.Core.Dominio;
using System.Linq;

namespace App.Infra.Contexto
{
    public static class AppDBSeedData
    {
        public static void EnsureSeedDataForContext(this AppDBContext context)
        {
            if (context.Usuarios.Any())
            {
                return;
            }

            var usuarioPrueba = new Usuario { UserName = "Fulano de Tal", Email = "fulano@gmail.com" };
            context.Usuarios.Add(usuarioPrueba);
            context.SaveChanges();
        }
    }
}
