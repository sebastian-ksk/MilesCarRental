# Miles Cart Rental API

API para el manejo de la renta de veh�culos de la empresa Miles Car Rental.


Autor: [Sebastian Castellanos  Pati�o](https://github.com/sebastian-ksk)

## Desarrollo de Prueba Tecnica

## 1.Desarrollo de Aplicaci�n

La empresa Miles Car Rental requiere el desarrollo de una aplicaci�n para el
manejo de la renta de sus veh�culos. Inicialmente, necesitan que cuando un
cliente realice una solicitud de un veh�culo, la aplicaci�n liste las diferentes
opciones que ofrece la compa��a y que pueda almacenar la informaci�n del
cliente, sus preferencias, as� como realizar reservas y finalizar la renta del
vehiculo. Dado que se encuentra en una fase exploratoria, se solicitan los
siguientes entregables:

## A. Diagrama de Clases

El diagrama de clases de nuestro proyecto ilustra la estructura de los modelos y
sus relaciones dentro de la aplicaci�n de alquiler y reservaci�n de veh�culos.
Los modelos principales incluyen Customer, Reservation, Rental, y Vehicle, 
cada uno con propiedades espec�ficas que reflejan los requisitos y caracter�sticas del dominio de la aplicaci�n.

![Diagrama de Clases](./diagrama_de_clases.png)


- **Reservation**: Refleja una reserva hecha por un cliente, con propiedades como `Id`, `CustomerId`, `VehicleId`, `StartDate`, `EndDate`, y `Status`.

- **Rental**: Similar a `Reservation`, pero para alquileres. Incluye `Id`, `CustomerId`, `VehicleId`, `StartDate`, `EndDate`, y `Status`.

- **Vehicle**: Detalla los veh�culos disponibles, con `Id`, `Make`, `Model`, `Year`, `Color`, y `LicensePlate`.

### Relaciones

- **Clientes a Reservaciones y Alquileres**: Una relaci�n uno a muchos, indicando que un cliente puede tener m�ltiples reservaciones y alquileres.

- **Reservaciones y Alquileres a Clientes y Veh�culos**: Relaciones muchos a uno, cada reserva o alquiler est� vinculado a un �nico cliente y veh�culo.

## B. Seudoc�digo y Explicaci�n de Proyecto

Este proyecto se estructura en tres capas principales: API, BLL (Capa de L�gica de Negocio), y 
DAL (Capa de Acceso a Datos), siguiendo el patr�n de dise�o de software de tres capas. Este enfoque
modulariza la aplicaci�n, separando la interfaz de usuario (UI), la l�gica de negocio, y el acceso a datos, lo que facilita el mantenimiento y la escalabilidad.

## Capas del Proyecto

### API

La capa API act�a como la interfaz entre el usuario y la l�gica de negocio de la aplicaci�n. Esta capa recibe las solicitudes de los usuarios, las procesa a trav�s de los controladores adecuados, y devuelve las respuestas correspondientes.

- **Controladores**: Cada controlador en la API gestiona un conjunto espec�fico de rutas relacionadas con una entidad o un conjunto de operaciones l�gicas. Los controladores dependen de los servicios definidos en la BLL para ejecutar la l�gica de negocio.
- **ApiResponse**: Para estandarizar las respuestas de la API, se utiliza la clase `ApiResponse<T>`. Esta clase encapsula la respuesta HTTP y proporciona una estructura coherente para las respuestas del servidor.

- `Success`: Un booleano que indica si la operaci�n fue exitosa o no.
- `Message`: Un mensaje descriptivo que acompa�a a la respuesta.
- `Data`: Los datos devueltos por el servidor (puede ser un objeto o una colecci�n).
- `Errors`: Una lista de mensajes de error, si la operaci�n no fue exitosa.

### BLL (Capa de L�gica de Negocio)

La BLL contiene la l�gica de negocio central de la aplicaci�n. Esta capa procesa la entrada recibida de la capa API, aplica las reglas de negocio correspondientes, y ejecuta las operaciones necesarias, interactuando con la DAL para recuperar o almacenar datos.

- **Servicios**: Los servicios en la BLL encapsulan la l�gica de negocio espec�fica de la aplicaci�n. Cada servicio es responsable de una parte l�gica del dominio de la aplicaci�n y puede depender de uno o m�s repositorios de la DAL para acceder a los datos necesarios.

### DAL (Capa de Acceso a Datos)

La DAL gestiona la conexi�n con la base de datos y la manipulaci�n de los datos. Esta capa abstrae las consultas de base de datos, proporcionando una interfaz para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sin exponer los detalles de la base de datos a las otras capas.

- **Repositorios**: Los repositorios en la DAL proporcionan m�todos para interactuar con la base de datos. Cada repositorio se centra en una entidad espec�fica y ofrece operaciones para consultar y manipular sus datos. Los servicios de la BLL utilizan estos repositorios para acceder y modificar datos seg�n la l�gica de negocio.

## Conexiones entre Controladores, Servicios y Repositorios

- **Controladores -> Servicios**: Los controladores de la API invocan servicios de la BLL para ejecutar operaciones de negocio. Esta separaci�n permite que la l�gica de negocio se mantenga independiente de la interfaz de usuario.

- **Servicios -> Repositorios**: Los servicios en la BLL utilizan repositorios de la DAL para acceder y manipular datos. Esta arquitectura permite reutilizar la l�gica de acceso a datos y mantener la l�gica de negocio separada de la implementaci�n de la base de datos.



## 2. Consulta SQL

# Procedimientos Almacenados para Consultas Espec�ficas

A Continuacion se describe los procedimientos almacenados implementados en la base de datos 
de la aplicaci�n para realizar consultas espec�ficas relacionadas con itinerarios, reservas
y m�todos de pago. Cada procedimiento almacenado tiene un objetivo claro y facilita la recuperaci�n
y gesti�n eficiente de la informaci�n dentro de la aplicaci�n. Ubicado en el proyecto  `MilesCarRental.SQL`

##  SP_CountItinerariesOverOneThousand


- **Objetivo**: Contar usuarios con consultas de itinerarios > $1000.
- **Variables**: `Valor` (itinerario).

## SP_UsersOver40InBogotaWithReservations

- **Objetivo**: Identificar usuarios > 40 a�os en Bogot� con reservas.
- **Variables**: `Edad`, `Ciudad` (usuario).

## SP_ReservationsByCreditCard

- **Objetivo**: Listar reservas pagadas con tarjeta de cr�dito.
- **Variables**: `MetodoPago` (reserva).

## SP_ReservationsPayOnArrival

- **Objetivo**: Listar reservas con pago en destino.
- **Variables**: `MetodoPago` (reserva).

## SP_ActiveAndCancelledReservations

- **Objetivo**: Mostrar reservas activas y canceladas.
- **Variables**: `Estado` (reserva).

---
