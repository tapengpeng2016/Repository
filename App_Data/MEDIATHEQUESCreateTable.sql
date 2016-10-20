-- USAGER --------------------------------------------------------------
CREATE TABLE [dbo].[Usager] (
    [idUsager]     INT            IDENTITY (1, 1) NOT NULL,
    [nom]           NVARCHAR (150) NOT NULL,
    [prenom]        NVARCHAR (150) NOT NULL,
    [dateNaissance] DATE	          NULL,
    [mail]			NVARCHAR(150)	NOT NULL, 
    [motDePasse]	NVARCHAR(150)		NOT NULL,
	[statut] INT NOT NULL
    PRIMARY KEY CLUSTERED ([idUsager] ASC)
);
-- FORMAT ----------------------------------------------------------------
CREATE TABLE [dbo].[Format] (
    [idFormat]      INT            IDENTITY (1, 1) NOT NULL,
    [libelle] NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([idFormat] ASC)
);
-- GENRE ------------------------------------------------------------------
CREATE TABLE [dbo].[Genre] (
    [idGenre]      INT            IDENTITY (1, 1) NOT NULL,
    [libelle] NVARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([idGenre] ASC)
);
-- ARTICLE ----------------------------------------------------------------
CREATE TABLE [dbo].[Article] (
    [idArticle] INT            IDENTITY (1, 1) NOT NULL,
    [nom]       NVARCHAR (350) NOT NULL,
    [idFormat]  INT            NOT NULL,
    [idGenre]   INT            NOT NULL,
    [acteurs]   NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([idArticle] ASC),
    CONSTRAINT [FK_Article_Genre] FOREIGN KEY ([idGenre]) REFERENCES [dbo].[Genre] ([idGenre]),
    CONSTRAINT [FK_Article_Format] FOREIGN KEY ([idFormat]) REFERENCES [dbo].[Format] ([idFormat])
);
-- EXEMPLAIRE --------------------------------------------------------------
CREATE TABLE [dbo].[Exemplaire] (
    [idExemplaire]	INT IDENTITY (1, 1) NOT NULL,
    [numero]		INT     NOT NULL,
    [idArticle]		INT		NOT NULL,
    [idEmprunt]		INT    NULL,
    PRIMARY KEY CLUSTERED ([idExemplaire] ASC),
	CONSTRAINT [FK_Exemplaire_Article] FOREIGN KEY ([idArticle]) REFERENCES [dbo].[Article] ([idArticle])
);
-- EMPRUNT ------------------------------------------------------------------
CREATE TABLE [dbo].[Emprunt] (
    [idEmprunt]         INT  IDENTITY (1, 1) NOT NULL,
    [idUsager]          INT  NOT NULL,
    [idExemplaire]      INT  NOT NULL,
    [dateEmprunt]       DATE NOT NULL,
    [dateRetourEstimee] DATE NULL,
    [dateRetourReelle]  DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([idEmprunt] ASC),
    CONSTRAINT [FK_Emprunt_Exemplaire] FOREIGN KEY ([idExemplaire]) REFERENCES [dbo].[Exemplaire] ([idExemplaire]),
    CONSTRAINT [FK_Emprunt_Usager] FOREIGN KEY ([idUsager]) REFERENCES [dbo].[Usager] ([idUsager])
);
-- FOREIGN KEY idEmprunt dans EXEMPLAIRE --------------------------------------
ALTER TABLE [dbo].[Exemplaire]
ADD CONSTRAINT [FK_Exemplaire_Emprunt] FOREIGN KEY ([idEmprunt]) REFERENCES [dbo].[Emprunt] ([idEmprunt]);
-- RESERVATION ----------------------------------------------------------------
CREATE TABLE [dbo].[Reservation] (
    [idReservation]               INT  IDENTITY (1, 1) NOT NULL,
    [idUsager]        INT  NOT NULL,
    [idExemplaire]    INT  NOT NULL,
    [dateReservation] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([idReservation] ASC),
    CONSTRAINT [FK_Reservation_Usager] FOREIGN KEY ([idUsager]) REFERENCES [dbo].[Usager] ([idUsager]),
    CONSTRAINT [FK_Reservation_Exemplaire] FOREIGN KEY ([idExemplaire]) REFERENCES [dbo].[Exemplaire] ([idExemplaire])
);
-- TARIF -----------------------------------------------------------------------
CREATE TABLE [dbo].[Tarif] (
    [idTarif]    INT            IDENTITY (1, 1) NOT NULL,
    [type]  NVARCHAR (150) NOT NULL,
    [tarif] FLOAT NOT NULL,
    PRIMARY KEY CLUSTERED ([idTarif] ASC)
);
-- ABONNEMENT ------------------------------------------------------------------
CREATE TABLE [dbo].[Abonnement] (
    [idAbonnement]   INT  IDENTITY (1, 1) NOT NULL,
    [idUsager]       INT  NOT NULL,
    [idTarif]        INT  NOT NULL,
    [dateAbonnement] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([idAbonnement] ASC),
    CONSTRAINT [FK_Abonnement_Tarif] FOREIGN KEY ([idTarif]) REFERENCES [dbo].[Tarif] ([idTarif]),
    CONSTRAINT [FK_Abonnement_Usager] FOREIGN KEY ([idUsager]) REFERENCES [dbo].[Usager] ([idUsager])
);