# App.Test

Este proyecto está pensado para Implementar patrones de prueba sobre los proyectos 

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