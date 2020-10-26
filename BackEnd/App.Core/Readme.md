# Dependencias

Aquí se presentan los Nuggets instalados sobre el proyecto.

## Soporte para validaciones de modelo MVC (ModelState)

+ dotnet add package Microsoft.AspNetCore.Mvc

## Soporte para manejo de códigos de error HTTP

+ dotnet add package Microsoft.AspNetCore.Http

```plantuml
@startuml
package App.Core{
  namespace App.Core.Interfaces #DDDDDD{
  !include ./Interfaces/IComentarioRepositorio.puml
  !include ./Interfaces/IPostItemRepositorio.puml
  !include ./Interfaces/IUsuarioRepositorio.puml
  }
  namespace App.Core.Servicios #DDDDDD{
    !include ./Servicios/IPostItemServicio.puml
    !include ./Servicios/PostItemServicio.puml
    !include ./Servicios/IUsuarioServicio.puml
    !include ./Servicios/UsuariosServicio.puml
  }
}
package App.Infra{
  namespace App.Infra.Repositorios #DDDDDD{
    !include ../App.Infra/Repositorios/ComentarioRepositorio.puml
    !include ../App.Infra/Repositorios/PostItemRepositorio.puml
    !include ../App.Infra/Repositorios/UsuarioRepositorio.puml
  }
}
package App.Api{
  namespace App.Api.Controllers #DDDDDD{
    !include ../App.Api/Controllers/PostItemController.puml
  }
}

@enduml
```

conda install -c conda-forge pandoc pandocfilters
pip install pandoc-plantuml-filter

pandoc -s --from markdown --filter pandoc-plantuml --filter pandoc-citeproc --filter pandoc-crossref --pdf-engine=pdflatex --template /home/dell/.pandoc/templates/eisvogel/eisvogel.tex --listings -o example.pdf

> desde Bash CLI
```bash
 pandoc -s --from markdown --filter pandoc-plantuml --filter pandoc-citeproc --filter pandoc-crossref --pdf-engine=pdflatex --template C:/Users/asus/AppData/Local/Pandoc/templates/eisvogel/eisvogel.tex --listings -o example.pdf
```

## Referencias

* BackEnd/PlantUml-gen/PlantUmlClassDiagramGenerator.exe BackEnd/App.Core/Interfaces/IComentarioRepositorio.cs
* BackEnd/PlantUml-gen/PlantUmlClassDiagramGenerator.exe BackEnd/App.Core/Interfaces/IPostItemRepositorio.cs
* BackEnd/PlantUml-gen/PlantUmlClassDiagramGenerator.exe BackEnd/App.Core/Interfaces/IUsuarioRepositorio.cs