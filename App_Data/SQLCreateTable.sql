CREATE TABLE [dbo].[Abonnement] (
    [Id_Abonnement]   INT      NOT NULL,
    [Id_Usager]       INT      NOT NULL,
    [Id_Tarif]        INT      IDENTITY (1, 1) NOT NULL,
    [Date_Abonnement] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Abonnement] ASC)
);

CREATE TABLE [dbo].[Article] (
    [Id_Article] INT           IDENTITY (1, 1) NOT NULL,
    [Nom]        NVARCHAR (50) NOT NULL,
    [Id_Format]  INT           NOT NULL,
    [Id_Genre]   INT           NOT NULL,
    [Auteur]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_Article] ASC)
);

CREATE TABLE [dbo].[Compte] (
    [Id_Compte] INT IDENTITY (1, 1) NOT NULL,
    [Id_Usager] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Compte] ASC)
);

CREATE TABLE [dbo].[Emprunt] (
    [Id_Emprunt]        INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usager]         INT      NOT NULL,
    [Id_Exemplaire]     INT      NOT NULL,
    [DateRetourEstimee] DATETIME NOT NULL,
    [DateRetourReelle]  DATETIME NULL,
    [DateEmprunt]       DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Emprunt] ASC)
);
CREATE TABLE [dbo].[Exemplaire] (
    [Id_Exemplaire] INT IDENTITY (1, 1) NOT NULL,
    [Numero]        INT NULL,
    [Id_Article]    INT NOT NULL,
    [Id_Emprunt]    INT DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id_Exemplaire] ASC)
);

CREATE TABLE [dbo].[Format_article] (
    [Id_Format]      INT        IDENTITY (1, 1) NOT NULL,
    [Libelle_Format] NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Format] ASC)
);
CREATE TABLE [dbo].[Genre] (
    [Id_Genre]      INT        IDENTITY (1, 1) NOT NULL,
    [Libelle_Genre] NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Genre] ASC)
);

CREATE TABLE [dbo].[Reservation] (
    [Id_Reservation]   INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usager]        INT      NOT NULL,
    [Id_Exemplaire]    INT      NOT NULL,
    [Date_Reservation] DATETIME NOT NULL,
    CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([Id_Reservation] ASC)
);
CREATE TABLE [dbo].[Tarif] (
    [Id_Tarif] INT        IDENTITY (1, 1) NOT NULL,
    [Type]     NCHAR (10) NULL,
    [Tarif]    FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Tarif] ASC)
);

CREATE TABLE [dbo].[Usager] (
    [Id_Usager]     INT           IDENTITY (1, 1) NOT NULL,
    [Nom]           NVARCHAR (50) NOT NULL,
    [Prenom]        NVARCHAR (50) NOT NULL,
    [DateNaissance] DATETIME      NULL,
    [Identifiant]   NVARCHAR (50) NOT NULL,
    [mdp]           NVARCHAR (50) NOT NULL,
    [acces]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Usager] ASC)
);