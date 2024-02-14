CREATE PROCEDURE [dbo].[SP_ReservationsByCreditCard]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT Id, UserId
    FROM Reservations
    WHERE PaymentMethod = 'credit-card';
END

