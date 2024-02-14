# Miles Cart Rental API

## Explciacioón de Seudocódigo


## Diagrama de Clases

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

