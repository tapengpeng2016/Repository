CREATE PROCEDURE [ReserverArticle]
 @idArticle int,
 @idUsager int
AS
INSERT INTO [dbo].[Reservation] 
([Id_Usager], [Id_Exemplaire], [Date_Reservation])
VALUES 
(@Usager, 
(SELECT TOP 1 X.Id_Exemplaire
	FROM [dbo].[Exemplaire] as X
	WHERE X.Id_Article = @idArticle
	AND X.Id_Exemplaire NOT IN (SELECT Id_Exemplaire 
									FROM [dbo].[Reservation] 
									WHERE [Id_Usager] = @idUsager)), 
GETDATE());
GO