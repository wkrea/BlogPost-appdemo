using System.Collections.Generic;
using System;
using System.Linq;

using App.Core.Dominio;

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

            var usuarioPrueba = new Usuario { Id=1, UserName = "Fulano de Tal", Email = "fulano@gmail.com" };
            context.Usuarios.Add(usuarioPrueba);

            Comentario comment1 = new Comentario{Id=1, PostId=1, CreadoFecha = DateTime.Now.AddDays(1), Texto = "Comentario Inicial Post 1" };
            Comentario comment2 = new Comentario{Id=2, PostId=1, CreadoFecha = DateTime.Now.AddDays(2), Texto = "Comentario Siguiente Post 1" };
            Comentario comment3 = new Comentario{Id=3, PostId=1, CreadoFecha = DateTime.Now.AddDays(2), Texto = "Comentario Final Post 1" };
            Comentario comment4 = new Comentario{Id=4, PostId=2, CreadoFecha = DateTime.Now.AddDays(3), Texto = "Comentario Inicial Post 2" };

            List<Comentario> comentarios = new List<Comentario>();
            comentarios.AddRange(new List<Comentario>(){comment1, comment2, comment3});

            context.Comentarios.AddRange(comentarios);

            var postPrueba1 = new PostItem { Id=1, 
                                CreadoFecha = DateTime.Now, 
                                ModificadoFecha = DateTime.Now, 
                                UserId=1, 
                                Texto = "Post de Fulano de Tal", 
                                Comentarios = comentarios};

            comentarios.Clear();
            comentarios.Add(comment4);
            
            context.Comentarios.AddRange(comentarios);

            var postPrueba2 = new PostItem { Id=2, 
                                CreadoFecha = DateTime.Now.AddDays(1), 
                                ModificadoFecha = DateTime.Now.AddDays(2), 
                                UserId=1, 
                                Texto = "Post #2 de Fulano de Tal", 
                                Comentarios = comentarios};

            context.PostItems.Add(postPrueba1);
            context.PostItems.Add(postPrueba2);
            context.SaveChanges();
        }
    }
}
