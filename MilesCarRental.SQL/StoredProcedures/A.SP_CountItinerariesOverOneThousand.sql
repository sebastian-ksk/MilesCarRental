CREATE PROCEDURE [dbo].[SP_CountItinerariesOverOneThousand]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT COUNT(DISTINCT UserId) AS NumberOfUsers
    FROM Itineraries
    WHERE Price > 1000;
END