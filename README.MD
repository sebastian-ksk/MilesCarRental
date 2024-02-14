# Miles Cart Rental API

API para el manejo de la renta de vehículos de la empresa Miles Car Rental.


Autor: [Sebastian Castellanos  Patiño](https://github.com/sebastian-ksk)

## Desarrollo de Prueba Tecnica

## 1.Desarrollo de Aplicación

La empresa Miles Car Rental requiere el desarrollo de una aplicación para el
manejo de la renta de sus vehículos. Inicialmente, necesitan que cuando un
cliente realice una solicitud de un vehículo, la aplicación liste las diferentes
opciones que ofrece la compañía y que pueda almacenar la información del
cliente, sus preferencias, así como realizar reservas y finalizar la renta del
vehiculo. Dado que se encuentra en una fase exploratoria, se solicitan los
siguientes entregables:

## A. Diagrama de Clases

El diagrama de clases de nuestro proyecto ilustra la estructura de los modelos y
sus relaciones dentro de la aplicación de alquiler y reservación de vehículos.
Los modelos principales incluyen Customer, Reservation, Rental, y Vehicle, 
cada uno con propiedades específicas que reflejan los requisitos y características del dominio de la aplicación.

![Diagrama de Clases](./diagrama_de_clases.png)


- **Reservation**: Refleja una reserva hecha por un cliente, con propiedades como `Id`, `CustomerId`, `VehicleId`, `StartDate`, `EndDate`, y `Status`.

- **Rental**: Similar a `Reservation`, pero para alquileres. Incluye `Id`, `CustomerId`, `VehicleId`, `StartDate`, `EndDate`, y `Status`.

- **Vehicle**: Detalla los vehículos disponibles, con `Id`, `Make`, `Model`, `Year`, `Color`, y `LicensePlate`.

### Relaciones

- **Clientes a Reservaciones y Alquileres**: Una relación uno a muchos, indicando que un cliente puede tener múltiples reservaciones y alquileres.

- **Reservaciones y Alquileres a Clientes y Vehículos**: Relaciones muchos a uno, cada reserva o alquiler está vinculado a un único cliente y vehículo.

## B. Seudocódigo y Explicación de Proyecto

Este proyecto se estructura en tres capas principales: API, BLL (Capa de Lógica de Negocio), y 
DAL (Capa de Acceso a Datos), siguiendo el patrón de diseño de software de tres capas. Este enfoque
modulariza la aplicación, separando la interfaz de usuario (UI), la lógica de negocio, y el acceso a datos, lo que facilita el mantenimiento y la escalabilidad.

## Capas del Proyecto

### API

La capa API actúa como la interfaz entre el usuario y la lógica de negocio de la aplicación. Esta capa recibe las solicitudes de los usuarios, las procesa a través de los controladores adecuados, y devuelve las respuestas correspondientes.

- **Controladores**: Cada controlador en la API gestiona un conjunto específico de rutas relacionadas con una entidad o un conjunto de operaciones lógicas. Los controladores dependen de los servicios definidos en la BLL para ejecutar la lógica de negocio.
- **ApiResponse**: Para estandarizar las respuestas de la API, se utiliza la clase `ApiResponse<T>`. Esta clase encapsula la respuesta HTTP y proporciona una estructura coherente para las respuestas del servidor.

- `Success`: Un booleano que indica si la operación fue exitosa o no.
- `Message`: Un mensaje descriptivo que acompaña a la respuesta.
- `Data`: Los datos devueltos por el servidor (puede ser un objeto o una colección).
- `Errors`: Una lista de mensajes de error, si la operación no fue exitosa.

### BLL (Capa de Lógica de Negocio)

La BLL contiene la lógica de negocio central de la aplicación. Esta capa procesa la entrada recibida de la capa API, aplica las reglas de negocio correspondientes, y ejecuta las operaciones necesarias, interactuando con la DAL para recuperar o almacenar datos.

- **Servicios**: Los servicios en la BLL encapsulan la lógica de negocio específica de la aplicación. Cada servicio es responsable de una parte lógica del dominio de la aplicación y puede depender de uno o más repositorios de la DAL para acceder a los datos necesarios.

### DAL (Capa de Acceso a Datos)

La DAL gestiona la conexión con la base de datos y la manipulación de los datos. Esta capa abstrae las consultas de base de datos, proporcionando una interfaz para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sin exponer los detalles de la base de datos a las otras capas.

- **Repositorios**: Los repositorios en la DAL proporcionan métodos para interactuar con la base de datos. Cada repositorio se centra en una entidad específica y ofrece operaciones para consultar y manipular sus datos. Los servicios de la BLL utilizan estos repositorios para acceder y modificar datos según la lógica de negocio.

## Conexiones entre Controladores, Servicios y Repositorios

- **Controladores -> Servicios**: Los controladores de la API invocan servicios de la BLL para ejecutar operaciones de negocio. Esta separación permite que la lógica de negocio se mantenga independiente de la interfaz de usuario.

- **Servicios -> Repositorios**: Los servicios en la BLL utilizan repositorios de la DAL para acceder y manipular datos. Esta arquitectura permite reutilizar la lógica de acceso a datos y mantener la lógica de negocio separada de la implementación de la base de datos.



## 2. Consulta SQL

# Procedimientos Almacenados para Consultas Específicas

A Continuacion se describe los procedimientos almacenados implementados en la base de datos 
de la aplicación para realizar consultas específicas relacionadas con itinerarios, reservas
y métodos de pago. Cada procedimiento almacenado tiene un objetivo claro y facilita la recuperación
y gestión eficiente de la información dentro de la aplicación. Ubicado en el proyecto  `MilesCarRental.SQL`

##  SP_CountItinerariesOverOneThousand


- **Objetivo**: Contar usuarios con consultas de itinerarios > $1000.
- **Variables**: `Valor` (itinerario).

## SP_UsersOver40InBogotaWithReservations

- **Objetivo**: Identificar usuarios > 40 años en Bogotá con reservas.
- **Variables**: `Edad`, `Ciudad` (usuario).

## SP_ReservationsByCreditCard

- **Objetivo**: Listar reservas pagadas con tarjeta de crédito.
- **Variables**: `MetodoPago` (reserva).

## SP_ReservationsPayOnArrival

- **Objetivo**: Listar reservas con pago en destino.
- **Variables**: `MetodoPago` (reserva).

## SP_ActiveAndCancelledReservations

- **Objetivo**: Mostrar reservas activas y canceladas.
- **Variables**: `Estado` (reserva).

---
