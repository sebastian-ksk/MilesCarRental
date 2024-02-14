CREATE PROCEDURE [dbo].[SP_ActiveAndCancelledReservations]
	@param1 int = 0,
	@param2 int
AS
	SET NOCOUNT ON;
    SELECT Id, UserId, Status
    FROM Reservations
    WHERE Status IN ('active', 'cancelled');
RETURN 0
