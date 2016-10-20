

INSERT INTO [dbo].[Reservation] 
([Id_Usager], [Id_Exemplaire], [Date_Reservation])
VALUES 
(@idArticle, 
(SELECT TOP 1 X.Id_Exemplaire
	FROM [dbo].[Exemplaire] as X
	WHERE X.Id_Article = @idArticle
	AND X.Id_Exemplaire NOT IN (SELECT Id_Exemplaire FROM [dbo].[Reservation])), 
GETDATE());