
# App.Infra

Este proyecto está pensado para acoger la lógica de negocio y la construcción de la capa de persistencia del aplicativo demo, empleando el enfoque de desarrollo [Code First](#ref:codefirst) sobre [EntityFrameworkCore]
(#ref:EFCore).

## Contexto

* AppDBContext
* AppDBSeedData

### AppDBContexto

```plantuml
package App.Infra{
  namespace App.Infra.Contexto #DDDDDD{
    !include ./Contexto/AppDBContext.puml
    !include ./Contexto/AppDBSeedData.puml
  }
}
```

## Repositorios

* UsuarioRepositorio
* ComentarioRepositorio
* PostItemRepositorio

```plantuml
package App.Infra{
  namespace App.Infra.Contexto #DDDDDD{
    !include ./Repositorios/UsuarioRepositorio.puml
    !include ./Repositorios/ComentarioRepositorio.puml
    !include ./Repositorios/PostItemRepositorio.puml
  }
}
```

## Referencias

* [App.Api](https://github.com/wkrea/appdemo/tree/main/BackEnd/App.Api){#ref:App.Api}
* [App.Core](https://github.com/wkrea/appdemo/tree/main/BackEnd/App.Core){#ref:App.Core}
* [App.Infra](https://github.com/wkrea/appdemo/tree/main/BackEnd/App.Infra){#ref:App.Infra}
* [Code First EF](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database){#ref:codefirst}
* [Entity Framework documentation](https://docs.microsoft.com/en-us/ef/core/){#ref:EFCore}

```bash
./PlantUmlClassDiagramGenerator.exe ../../../../../../App.Infra/Contexto/AppDBContext.cs
./PlantUmlClassDiagramGenerator.exe ../../../../../../App.Infra/Contexto/AppDBSeedData.cs
./PlantUmlClassDiagramGenerator.exe ../../../../../../App.Infra/Repositorios/ComentarioRepositorio.cs
./PlantUmlClassDiagramGenerator.exe ../../../../../../App.Infra/Repositorios/PostItemRepositorio.cs
./PlantUmlClassDiagramGenerator.exe ../../../../../../App.Infra/Repositorios/UsuarioRepositorio.cs
```