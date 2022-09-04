# Web Api BDP 
## _Ejempo De Mini Api Bancaria_
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Api de Cuentas- Movimientos y Clientes

## Features

- Creacion de Clientes
- Creacion de Cuentas
- Movimiento de Debitos y Creditos
- Reporte y Estado de cuenta

## Installation

Es necesesario tener instalado Docker, NetCore 6.

Pasos para ejecutar el aplicativo:

Instalacion de la base de datos
```sh
$ docker pull mcr.microsoft.com/mssql/server:2019-latest
$ docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1450:1433 --name sqlserverdb -h mysqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

Ejecucion del aplicativo mediante Docker

```sh
$ docker build -t jalechon/bancawebapi .
$ docker run -d -p  80:8080 jalechon/bancawebapi
```
Verify the deployment by navigating to your server address in
your preferred browser.

```sh
127.0.0.1:8080
```
## Plugins

Archivos Necesarios.

| Plugin | README |
| ------ | ------ |
| Base de Datos | [/BancaWebApi/Extras/database.sql][PlDb] |
| Coleccion Postman | [/BancaWebApi/Extras/Pichincha.postman_collection.json][PlGh] |
| Dockerregistry | https://hub.docker.com/r/jalechon2603/bancawebapi |


## License

MIT


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [PlDb]: <https://github.com/JhonathanALM/BancaWebApi/blob/master/BancaWebApi/Extras/Pichincha.postman_collection.json>
   [PlGh]: <https://github.com/JhonathanALM/BancaWebApi/blob/master/BancaWebApi/Extras/database.sql>
