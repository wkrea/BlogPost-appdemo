# App.Test

Este proyecto está pensado para Implementar patrones de prueba sobre los proyectos.

## [App.Api](#ref:App.Api)

Contiene pruebas para los controladores en el caso de la y los que involucran respuestas del protocolo http y https.

Este proyecto se convierte en la fuente de datos para el FrontEnd que pueda ser implementado en cualquier tecnología que soporte protocolo y/o arquitectura REST.

## [App.Core](#ref:App.Core)

Aquí están contenidas las pruebas unitarias del proyecto intermediario App.core. La lógica de este proyecto involucra las acciones intermediarias de los servicios hacia los controladores la definición de las interfaces y su funcionamiento así como también la definición de los métodos de dominio y Data transfer objects (DTOs) que sean empleados por la aplicación. Es importante mencionar que, en este proyecto se alberga una lógica mapper entre DTOs y entidades de dominio

## [App.Infra](#ref:App.Infra)

Contiene pruebas unitarias para la lógica de negocio de la aplicación definida a través de los repositorios de manera que se puedan evaluar las acciones CRUD sobre la capa de persistencia

## Referencias

* [App.Api](https://github.com/wkrea/appdemo/tree/main/BackEnd/App.Api){#ref:App.Api}
* [App.Core](https://github.com/wkrea/appdemo/tree/main/BackEnd/App.Core){#ref:App.Core}
* [App.Infra](https://github.com/wkrea/appdemo/tree/main/BackEnd/App.Infra){#ref:App.Infra}

* [coveralls appdemo](https://coveralls.io/github/wkrea/appdemo)
* [pimp-your-repo-with-github-actions](https://www.michalbialecki.com/2020/01/30/pimp-your-repo-with-github-actions/)
* [coveralls-github-action](https://github.com/marketplace/actions/coveralls-github-action)
* [Testing .NET Core Apps with GitHub Actions](https://dev.to/kurtmkurtm/testing-net-core-apps-with-github-actions-3i76)
* [Code coverage with Coverlet in MSBuild and Azure Pipeline](https://ofpinewood.com/blog/code-coverage-with-coverlet-in-msbuild-and-azure-pipelines)
* [Measuring .NET Core Test Coverage with Coverlet](https://www.tonyranieri.com/blog/2019/07/31/Measuring-.NET-Core-Test-Coverage-with-Coverlet/)
* [Azure Pipelines - Getting Code Coverage info for a .net core app](https://abelsquidhead.com/index.php/2019/04/13/getting-code-coverage-info-for-a-net-core-app-in-azure-pipelines/)
* [Azure Pipelines - Computing code coverage for a .NET Core project with Azure DevOps and Coverlet](https://www.meziantou.net/computing-code-coverage-for-a-dotnet-core-project-with-azure-devops-and-coverlet.htm)
* [Microsoft Azure DevOps Coverage](https://docs.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops)
* [coverlet-action](https://github.com/b3b00/coverlet-action)