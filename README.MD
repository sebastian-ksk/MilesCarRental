# Miles Cart Rental API

## Explciacio�n de Seudoc�digo


## Diagrama de Clases

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
