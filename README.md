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

_Instalacion de la base de datos_
```sh
$ docker pull mcr.microsoft.com/mssql/server:2019-latest
$ docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1450:1433 --name sqlserverdb -h mysqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```
_Migracion de EF_
Es necesario primero la actualizacion de la base de datos utilizando los comandos EF, para ello se necesita estar en la carpeta de AccesoDatos
```sh
Add-Migration InitialCreate -o Migrations
update-Database
```
_Ejecucion del aplicativo mediante Docker (Opcional)_
En el directorio del dockerfile (raiz)
```sh
$ docker build -t jalechon/bancawebapi .
$ docker run -d -p  80:8080 jalechon/bancawebapi
```
Verify the deployment by navigating to your server address in
your preferred browser.

```sh
127.0.0.1:8080
```
## Ejemplo Respuesta
```sh
{
    "data": [
        {
            "fecha": "2022-09-03T20:13:32.3796372",
            "cliente": "JOSE LEMA",
            "numeroCuenta": "478758",
            "tipo": "CRED",
            "saldoInicial": 2000.00,
            "estado": "A",
            "movimiento": 78.00,
            "saldoDisponible": 2078.00
        },
        {
            "fecha": "2022-09-03T20:13:41.2636261",
            "cliente": "JOSE LEMA",
            "numeroCuenta": "478758",
            "tipo": "CRED",
            "saldoInicial": 2078.00,
            "estado": "A",
            "movimiento": 90.00,
            "saldoDisponible": 2168.00
        },
        {
            "fecha": "2022-09-03T20:13:44.4489936",
            "cliente": "JOSE LEMA",
            "numeroCuenta": "478758",
            "tipo": "CRED",
            "saldoInicial": 2168.00,
            "estado": "A",
            "movimiento": 30.00,
            "saldoDisponible": 2198.00
        },
        {
            "fecha": "2022-09-03T20:13:49.5815594",
            "cliente": "JOSE LEMA",
            "numeroCuenta": "478758",
            "tipo": "DEV",
            "saldoInicial": 2198.00,
            "estado": "A",
            "movimiento": -60.00,
            "saldoDisponible": 2138.00
        }
    ],
    "respuesta": "Created"
}
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
