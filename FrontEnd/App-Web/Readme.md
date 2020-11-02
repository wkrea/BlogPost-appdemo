<p>
    <h1 align="center"> Proyecto Angular </h1>
</p>

## Contexto

Este proyecto esta ideado, diseñado y desarrollado con la finalidad de recoger toda la lógica detrás de una interfaz web realizada en una tecnología reactiva web como lo es [Angular](https://angular.io/docs), este desarrollado esta dado en una arquitecura básica de MVC.

## Requisitos previos para la ejecución el Proyecto

Como requisitos previos para la ejecución de este proyecto se deben tener en cuenta algunas consideraciones a nivel de software, como lo es el tener instalado: NodeJS y Angular CLI.

### Instalar NodeJs

* Descargar el instalador de [NodeJS](https://nodejs.org/es/).
* Ejecutar el instalador.

### Instalar Angular
Una vez instalado NodeJS, se procede a abrir la consola de NodeJS <b>(Node.js command prompt)</b>, esto es con el fin de ejecutar los comandos para instalar angular y sus dependencias.

* Instalar Angular en su ultima versión:
```bash
npm i -g @angular/cli
```

* Si se desea, instalar angular en una versión especifica se debe utilizar el siguiente comando:
```bash
npm i -g @angular/cli@'N°. Version'
```

* Para verificar la versión de angular instalada:

```bash
ng --version
```

## Dependencias Adicionales del proyecto

Este proyecto tiene uso de algunas dependencias de ciertas librerias o frameworks visuales para tener una interfaz más definida y visualmente a tractiva hacia el usuario final-

Algunas de estas dependencias son:

* Boostrap.
* JQuery.
* PopperJS.
* Fontawesome
* NgToastr.
* Datatables.

## Configuración de Proxy

Se debe crear un archivo de tipo <b> config.proxy </b> para establecer una comunicación directa con el APIREST creada en .NETCORE esto se realiza de la siguiente manera:

* Se debe crear el archivo y llamarlo de la siguiente forma así:

```bash    
proxy.conf.json
```

* Seguido a ello se debe reajustar el inicio del proyecto en el archivo <b> package.json </b> más exactamente se modfican la linea de ng serve:

```bash
"scripts": {
    ...
    "start": "ng serve"
    ...
  }
```

Y se agrega <b> --proxy-config proxy.conf.json </b>, con el fin de que exista una comunicación con la API:

```bash
"scripts": {
    ...
    "start": "ng serve --proxy-config proxy.conf.json"
    ...
  }
```

* Por ultimo para iniciar el proyecto se debe tener en cuenta que se iniciar el proyecto de la API y a su vez el de angular con la siguiente linea: 

```bash
npm start
```