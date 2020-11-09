# appdemo

## Coverage
[![Coverage Status](https://coveralls.io/repos/github/wkrea/appdemo/badge.svg?branch=main)](https://coveralls.io/github/wkrea/appdemo?branch=main)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=wkrea_appdemo&metric=coverage)](https://sonarcloud.io/dashboard?id=wkrea_appdemo)

## QA metrics
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=wkrea_appdemo&metric=alert_status)](https://sonarcloud.io/dashboard?id=wkrea_appdemo)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=wkrea_appdemo&metric=bugs)](https://sonarcloud.io/dashboard?id=wkrea_appdemo)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=wkrea_appdemo&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=wkrea_appdemo)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=wkrea_appdemo&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=wkrea_appdemo)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=wkrea_appdemo&metric=code_smells)](https://sonarcloud.io/dashboard?id=wkrea_appdemo)

Aplicación demo para aplicación de metodología modular

La aplicación puedes ser ejecutada de varias maneras para propósitos de desarrollo y/o prueba.

## Emplear una Base de Datos en memoria

Escenario facilita la ejecución del aplicativo en modo de prueba O desarrollo de forma que no requerirá hacer ningún ajuste pues toda la configuración del aplicativo está realizada por defecto dentro del repositorio.

### Ejecución

1. Ubicado en `appdemo\BackEnd\App.Api`
2. Ejecute `dotnet build` y luego Ejecute `dotnet run`
3. Verifique que puede obtener un resultado en alguna de las siguientes rutas
     * [https://localhost:5001/api/users](https://localhost:5001/api/users)
     * [http://localhost:5000/api/users](http://localhost:5000/api/users)

## Empleando una Base de Datos en Docker

Para facilitar el despliegue y prueba de la aplicación se puede apoyar del archivo docker-compose ubicado en la raíz de repositorio en el se crea un servicio de base de datos para el cual ya se han definido nombres de base de datos y contraseñas compatibles con el aplicativo de no de manera que no se requiere hacer ningún ajuste

### Ajustes previos

Ajuste el archivo `BackEnd\App.Api\ServiceExtensions.cs`
para utilice la sentencia:

```C#
optionsBuilder.UseSqlServer(connectionString); // SqlServer
```

en vez de:

```C#
optionsBuilder.UseInMemoryDatabase("db_memoria"); // En memoria
```

o viceversa, según sea el caso de su preferencia.

### Ejecución Local de la aplicación AppDemo

1. Ubicado en `appdemo`
2. Ejecute `docker-compose up db`
3. Ubiquese en `appdemo\BackEnd\App.Api`
4. Ejecute `dotnet build` y luego Ejecute `dotnet run`
5. Verifique que puede obtener un resultado en alguna de las siguientes rutas
   * [https://localhost:5001/api/users](https://localhost:5001/api/users)
   * [http://localhost:5000/api/users](http://localhost:5000/api/users)

## Arquitectura

![your-UML-diagram-name](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/jonashackt/plantuml-markdown/master/example-uml.iuml)

### Visión General (appdemo)

```plantuml
!include ./Assets/Overview_appdemo.puml
```

![Overview_appdemo](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/wkrea/appdemo/main/Assets/Overview_appdemo.puml)

```plantuml
@startuml

scale 0.8

skinparam interface {
  backgroundColor RosyBrown
  borderColor orange
}

skinparam component {
  FontSize 13
  BackgroundColor<<Apache>> Red
  BorderColor<<Apache>> #FF6655
  FontName Courier
  BorderColor black
  BackgroundColor gold
  ArrowFontName Impact
  ArrowColor #FF6655
  ArrowFontColor #777777
}

package App.Infra {
    namespace App.Infra.Repositorio #DDDDDD{
            interface IUsuarioRepositorio {
                GuardarContext() : Task
                Listar() : Task<IEnumerable<Usuario>>
                Crear(usuario:Usuario) : Task
                Eliminar(id:int) : Task
                Editar(usuario:Usuario) : Task
                BuscarXId(Id:int) : Task<Usuario>
            }
            class UsuarioRepositorio {
                - <<readonly>> _context : AppDBContext
                + UsuarioRepositorio(AppDBContext:AppDBContext)
                + <<async>> GuardarContext() : Task
                + <<async>> Listar() : Task<IEnumerable<Usuario>>
                + <<async>> BuscarXId(id:int) : Task<Usuario>
                + <<async>> Crear(usuario:Usuario) : Task
                + <<async>> Editar(usuario:Usuario) : Task
                + <<async>> Eliminar(id:int) : Task
            }
       }

App.Infra.Repositorio.IUsuarioRepositorio <|-left- App.Infra.Repositorio.UsuarioRepositorio
}

package App.Core{
    namespace App.Core.Servicios #DDDDDD{
         interface IUsuarioServicio {
            GetUsuarios() : Task<IEnumerable<Usuario>>
            GetUsuario(id:int) : Task<Usuario>
            CrearUsuario(usuario:Usuario) : Task<IEnumerable<ErrorBase>>
            EditarUsuario(usuario:Usuario) : Task<IEnumerable<ErrorBase>>
            EliminarUsuario(id:int) : Task
        }
        class UsuariosServicio {
            - <<readonly>> _userRepo : IUsuarioRepositorio
            + UsuariosServicio(usuarioRepositorio:IUsuarioRepositorio)
            + <<async>> GetUsuarios() : Task<IEnumerable<Usuario>>
            + GetUsuario(id:int) : Task<Usuario>
            + <<async>> CrearUsuario(usuario:Usuario) : Task<IEnumerable<ErrorBase>>
            + <<async>> EditarUsuario(usuario:Usuario) : Task<IEnumerable<ErrorBase>>
            + <<async>> EliminarUsuario(id:int) : Task
        }
    }
   App.Core.Servicios.IUsuarioServicio <|-right App.Core.Servicios.UsuariosServicio

    App.Core.Servicios.UsuariosServicio --down0)-- App.Infra.Repositorio.IUsuarioRepositorio
}

package App.Api{
    namespace App.Api.Controllers #DDDDDD{
       class UsuarioController {
         - <<readonly>> usersService : IUsuarioServicio
         + UsuarioController(usersService:IUsuarioServicio)
         + <<async>> GetUsers() : Task<IActionResult>
         + <<async>> GetUser(id:int) : Task<IActionResult>
      }
      ControllerBase <|-left- UsuarioController
    }
    App.Api.Controllers.UsuarioController --down0)-- App.Core.Servicios.IUsuarioServicio
}

package "FrontEnd" {
   '  -left-o HTTpClient
  app -left-|> HTTpClient
  HTTpClient -right-o App.Api.Controllers.ControllerBase
}

' package command {
'     class AbstractCommand
    
' }

' package net {
'     class AbstractConsumer
'     interface Inject<E>
' }

' package plug {
'     interface Pluggable
' }



' App.Infra.Repositorio.Bootstrap --|> AbstractConsumer
' Bootstrap ..|> Inject
' Bootstrap ..|> Pluggable


' HaltCommand --|> AbstractCommand
' HaltCommand ..> Bootstrap


' node "FrontEnd" {
'   ' [app] ..> () HTTPClient : use
'   [app] ..> () HTTPClient : use
' }

' cloud {
'   [HTTP/HTTPS]  --(0- HTTPClient : implements
' }

' node "App.Infra" {
'   package "Contexto"{
'     [AppDBSeedContext] ..> [AppDBContext] : extends
'     [AppDBContext] ..> () EFCore : use
'   }
'   package "Repositorios"{
'     [PostItemRepositorio] --(0- () IPostItemRepositorio : implements
'     [UsuarioRepositorio] --(0- () IUsuarioRepositorio  : implements

'     [PostItemRepositorio] ..> () AppDBContext : use
'     [UsuarioRepositorio] ..> () AppDBContext : use
'    }
' }

' package App.Infra{
'       namespace App.Infra.Contexto #DDDDDD{
'          !include ./BackEnd/App.Infra/Repositorios/UsuarioRepositorio.puml
'          '  !include ./Repositorios/ComentarioRepositorio.puml
'          '  !include ./Repositorios/PostItemRepositorio.puml
'    }
' }

' database "EFCore" {
'   Database SqlServer
' }

' node "App.Core" {
'    [Servicios]
'    package "Servicios"{
'       [PostItemServicio] --(0- () IPostItemServicio : implements
'       [UsuariosServicio] --(0- () IUsuariosServicio : implements
'    }
'    [PostItemServicio] ..> () IPostItemRepositorio : use
'    [UsuariosServicio] ..> () IUsuarioRepositorio : use
' }

' node "App.Api" {
'   [Controllers]
' '   Contexto ..> [Startup] : use
' '   Repositorios ..> [Startup] : use
'   package "Controllers"{
'    [PostItemControllers] ..> [HTTP/HTTPS] : use
'    [UserControllers] ..> [HTTP/HTTPS] : use
'    [PostItemControllers] ..> () IPostItemServicio : use
'    [UserControllers] ..> () IUsuariosServicio : use
'   }
' }

@enduml
```

### Vista Detallada (appdemo)

```plantuml
!include ./Assets/Detail_appdemo.puml
```

<!-- 
<iframe width="100%" height="500" src=http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/wkrea/appdemo/main/Assets/Detail_appdemo.puml>
![Detail_appdemo](http://www.plantuml.com/plantuml/proxy?cache=no&src=https://raw.githubusercontent.com/wkrea/appdemo/main/Assets/Detail_appdemo.puml)
</iframe> -->

## Referencias

* [UML conventions](https://crashedmind.github.io/PlantUMLHitchhikersGuide/PlantUMLSpriteLibraries/plantuml_sprites.html)
* [Component UML Diagrams Plantuml](https://real-world-plantuml.com/umls/4860331021041664)
* [Proxy render UML](https://github.com/jonashackt/plantuml-markdown#2-integrate-plantuml-render-engine-with-github-markdown)
* [plantuml-styles renders](https://github.com/wkrea/plantuml-styles)
* [repository-pattern-csharp](https://codewithshadman.com/repository-pattern-csharp/)
