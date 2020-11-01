# App.Test

Proyecto de pruebas de integración sobre App.Api

## Consideraciones

Se recomienda que para la ejecución de los test, sea empleado el archivo de solución en la raíz de BackEnd, para evitar [problemas de ejecución con XUnit y NetCore](https://github.com/microsoft/vstest/issues/1129), por [el manejo de los Guid de los proyectos](https://mohitgoyal.co/2018/09/08/sonarqube-fails-to-analyze-dotnet-core-code-with-error-duplicate-projectguid-00000000-0000-0000-0000-000000000000/)

```bash
dotnet test ./BackEnd/App.Api.sln
```

### Configuraciones

* Instalar la extensión de sonarlint
* Abrir la configuración de la extensión y Actualizar el path de Java **(Sonarlint › Ls: Java Home)** a la última versión (esto evita problemas con análisis de SonarCloud)

## Referencias

* https://dev.to/equiman/net-core-unit-test-and-code-coverage-with-visual-studio-code-37bp
* https://github.com/actions/setup-java
* https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
* https://github.com/ikemtz/NRSRx/blob/master/tools/sonarqube-create-project-guids.ps1