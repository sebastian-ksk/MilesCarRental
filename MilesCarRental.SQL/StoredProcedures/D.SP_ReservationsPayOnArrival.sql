CREATE PROCEDURE [dbo].[SP_ReservationsPayOnArrival]
AS
    SET NOCOUNT ON;
    
    SELECT Id, UserId
    FROM Reservations
    WHERE PaymentMethod = 'on-arrival';
RETURN 0
