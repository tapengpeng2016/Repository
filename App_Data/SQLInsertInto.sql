-- USAGER ---------------------------------------------------------------------------
INSERT INTO [dbo].[Usager] ([Nom], [Prenom], [DateNaissance], [Identifiant], [mdp], [acces]) 
VALUES
('MATTAR', 'Shadi', '09/03/1990', 'shadi@mattar.fr', '1234', 1),
('CHARBONNIER', 'Vincent', '', 'v.charbonnier@gmail.com', '1234', 0),
('TRAM', 'David', '05/06/1992', 'dav@tran.fr', '1234', 0),
('PEING','Huifang','08/04/1991','huifang@peing.fr','1234', 1),
('GOCEL', 'Eric', '09/04/1992', 'eric@gocel.fr', '1234', 0);
-- TARIF ----------------------------------------------------------------------------
INSERT INTO [dbo].[Tarif] ([Type], [Tarif])
VALUES ('Enfant', '150'),
		('Adulte', '250'),
		('Sénior', '200');
-- ABONNEMENT -----------------------------------------------------------------------
INSERT INTO [dbo].[Abonnement] ([Id_Abonnement], [Id_Usager], [Date_Abonnement])
VALUES  (1,2,'01/10/2016'), 
		(2,3,'18/10/2016'), 
		(3,3,'19/10/2016'),
		(4,1,'21/10/2016');
-- GENRE ----------------------------------------------------------------------------
INSERT INTO [dbo].[Genre] ([Libelle_Genre])
VALUES ('aventure'),('BD'),('comédie'),('action'), ('romantique'), ('thriller');
-- FORMAT ---------------------------------------------------------------------------
INSERT INTO [dbo].[Format_article] ([Libelle_Format])
VALUES ('Livre'),('magasine'),('DVD'),('Blu Ray');
-- ARTICLE --------------------------------------------------------------------------
INSERT INTO [dbo].[Article] ([Nom], [Id_Format], [id_Genre], [Auteur])
VALUES ('La mort dans la peau', 3, 4, 'Matt Dameon'),
		('Titanic', 3, 5, 'Dicaprio'),
		('La loi et l''ordre', 1, 4, 'Franco'),
		('Mon épée', 1, 2, 'LePetit'),
		('Le Parrain', 4, 6, 'Al Pacino');
-- EXEMPLAIRE ------------------------------------------------------------------------
INSERT INTO [dbo].[Exemplaire] ([Id_Article], [Numero])
VALUES  (1, 142),
		(1, 132),
		(2, 1432),
		(2, 1423),
		(3, 1231),
		(4, 1241),
		(5, 12412),
		(5, 1241),
		(5, 1231),
		(3, 142);
-- EMPRUNT ---------------------------------------------------------------------------
INSERT INTO [dbo].[Emprunt] 
([Id_Exemplaire], [Id_Usager], [DateEmprunt], [DateRetourEstimee], [DateRetourReelle])
	VALUES	(2, 2, '17/06/2016', '17/09/2016', '16/08/2016'),
			(5, 5, '01/10/2016', '01/12/2016', ''),
			(1, 1, '01/09/2016', '18/12/2016', '17/10/2016'),
			(3, 3, '01/10/2016', '01/12/2016', ''),
			(4, 1, '19/10/2016', '19/12/2016', '');
-- UPDATE EXEMPLAIRE -----------------------------------------------------------------
UPDATE [dbo].[Exemplaire]
	SET [Id_Emprunt] = 1 WHERE [Id_Exemplaire] = 1;
UPDATE [dbo].[Exemplaire]
	SET [Id_Emprunt] = 2 WHERE [Id_Exemplaire] = 3;
UPDATE [dbo].[Exemplaire]
	SET [Id_Emprunt] = 3 WHERE [Id_Exemplaire] = 4;
UPDATE [dbo].[Exemplaire]
	SET [Id_Emprunt] = 4 WHERE [Id_Exemplaire] = 2;
-- RESERVATION ----------------------------------------------------------------------
INSERT INTO [dbo].[Reservation]
([Id_Usager], [Id_Exemplaire], [Date_Reservation])
VALUES  (3, 3, '25/09/2016'),
		(5, 3, '12/10/2016'),
		(2, 4, '19/10/2016'),
		(2, 2, '18/10/2016');