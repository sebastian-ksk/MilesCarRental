CREATE PROCEDURE [dbo].[SP_UsersOver40InBogotaWithReservations]
AS
	SET NOCOUNT ON;
    
    SELECT DISTINCT U.Id, U.Name
    FROM UsersTable U
    INNER JOIN Reservations R ON U.Id = R.UserId
    WHERE DATEDIFF(year, U.BirthDate, GETDATE()) > 40
    AND U.City = 'Bogotá';
RETURN 0
