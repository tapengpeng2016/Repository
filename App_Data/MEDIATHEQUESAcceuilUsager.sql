-- DU GRAND ART ----
SELECT tab.idArticle as id, 
		tab.nomArticle as 'Titre de l''article', 
		F.libelle as 'Format', 
		G.libelle as 'Genre',
		tab.acteurs as 'Acteurs/Auteurs',
		COUNT(CASE WHEN tab.idEmprunt IS NULL THEN 1 ELSE NULL END) as 'Exemplaires disponibles',
		(CASE 
			WHEN COUNT(CASE WHEN tab.idEmprunt IS NULL THEN 1 ELSE NULL END) = 0 
				THEN 'Réserver' 
				ELSE 'Emprunter' 
		END) AS 'Disponibilité'
FROM 
	(SELECT A.idArticle AS idArticle, 
			A.nom AS nomArticle, 
			A.idFormat AS id_Format, 
			A.idGenre AS id_Genre, 
			A.acteurs AS acteurs, 
			E.idExemplaire AS idExemplaire, 
            E.numero AS numero, 
			E.idEmprunt
		FROM  Article as A,
              Exemplaire as E
		WHERE A.idArticle = E.idArticle) AS tab,
      [Format] AS F,
      [Genre] AS G
WHERE  id_Genre = G.idGenre
		AND id_Format = F.idFormat
GROUP BY tab.nomArticle, 
		tab.idArticle, 
		F.libelle, 
		G.libelle,
		tab.acteurs