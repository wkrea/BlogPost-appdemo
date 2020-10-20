using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Core.Interfaces;
using App.Core.Servicios;
using App.Core.Servicios.Validadores;
using App.Infra.Repositorios;
using App.Infra.Contexto;

namespace App.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlconnection:connectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(connectionString); // SqlServer
            // optionsBuilder.UseInMemoryDatabase("db_memoria"); // En memoria
            var context = new AppDBContext(optionsBuilder.Options);
            services.AddSingleton<IPostItemRepositorio>(new PostItemRepositorio(context));
            services.AddSingleton<IComentarioRepositorio>(new ComentarioRepositorio(context));
            services.AddSingleton<IUsuarioRepositorio>(new UsuarioRepositorio(context));
            context.EnsureSeedDataForContext();
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddSingleton<IPostItemServicio, PostItemServicio>();
            services.AddSingleton<PostValidador, PostValidador>();
            services.AddSingleton<ComentarioValidador, ComentarioValidador>();
            services.AddSingleton<IUsuarioServicio, UsuariosServicio>();
        }
    }
}
