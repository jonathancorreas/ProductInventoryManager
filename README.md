# Prueba Tecnica

Este proyecto es una API RESTful que gestiona un sistema de inventario de productos,
implementando con buenas prácticas de programación, patrones de diseño y principios SOLID.
La solución esta dockerizada y utiliza una base de datos relacional SQL Server.

## Requisitos

- Docker Desktop
- Microsoft SQL Server Management Studio

## Instrucciones para ejecutar el proyecto

Siga los pasos a continuación para ejecutar el proyecto utilizando `docker-compose`.

### Clonar el repositorio

Primero, clonar este repositorio en tu máquina local:

`git clone https://github.com/jonathan23456/ProductInventoryManager`


### Ejecutar archivo `docker-compose`

Ingresar a la carpeta donde se clono el proyecto

`cd ProductInventoryManager`

Luego ejecutar el siguiente comando `docker-compose up -d`

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen1.PNG)

Al finalizar de ejecutar el comando se debe visualizar que la red y los contenedores fueron creados correctamente.

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen2.PNG)

Verficar en el docker desktop que los contenedores esten corriendo correctamente.

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen3.PNG)

Ahora se debe ejecutar el script de creacion de las tablas de la base de datos, para eso se debe usar SQL Server Management Studio, las credenciales de conexion son:

- `Servidor: localhost,8005`
- `Login: sa`
- `Password: password@12345#`

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen4.PNG)

Crear la base de datos con el siguiente nombre `ProductInventoryManager`

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen5.PNG)

Ejecutar el script que se encuentra en la ruta <a href="https://github.com/jonathan23456/ProductInventoryManager/blob/main/scriptbd/scriptbd.sql" target="_blank">https://github.com/jonathan23456/ProductInventoryManager/blob/main/scriptbd/scriptbd.sql</a>

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen6.PNG)

Validar que las tablas fueron creadas correctamente

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen7.PNG)

Luego desde cualquier navegador web, ingresar a la siguiente URL: <a href="http://localhost:8009/swagger/index.html" target="_blank">http://localhost:8009/swagger/index.html</a> se debe visualizar la documentación en swagger del API 

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen8.PNG)

Se debe crear un usuario usando el metodo register del controlador Auth

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen9.PNG)

Luego ejecutar el metodo login del controlador Auth, este nos retornara el token de autenticación para poder usar los otros metodos del API

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen10.PNG)

Copiar el token e Ir al boton Authorize

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen11.PNG)

Copiar el token e Ir al boton Authorize

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen12.PNG)

Pegar el token y dar click en el botón Authorize, con esto el token ya se envia en la cabezera de los otros metodos del API, con esto, 
ya se lograra consumir cualquiera de los metodos, por ejemplo se puede consumir el metodo Get del controlador de Categorias, se deben visualizar las categorias.

![](https://github.com/jonathan23456/ProductInventoryManager/blob/main/imagenes/imagen13.PNG)
