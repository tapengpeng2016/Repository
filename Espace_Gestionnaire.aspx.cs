using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Espace_Gestionnaire : System.Web.UI.Page
{
    string usager;
    string acces;
    int int_acces;
    protected void Page_Load(object sender, EventArgs e)
    {
        Usager u=new Usager();
        /*u.RemplirGrid(@"SELECT tab.idArticle as id, 

        tab.nomArticle as 'Titre de l''article',
        F.Libelle_Format as 'Format',
        G.Libelle_Genre as 'Genre',
        tab.auteurs as 'Acteurs/Auteurs',
        COUNT(CASE WHEN tab.Id_Emprunt = 0 THEN 1 ELSE NULL END) as 'Exemplaires disponibles',
        (CASE
            WHEN COUNT(CASE WHEN tab.Id_Emprunt = 0 THEN 1 ELSE NULL END) = 0
                THEN 'Réserver'

                ELSE 'Emprunter'

        END) AS 'Disponibilité'
FROM
    (SELECT A.Id_Article AS idArticle,
            A.Nom AS nomArticle,
            A.Id_Format AS idFormat,
            A.Id_Genre AS idGenre,
            A.Auteur AS auteurs,
            E.Id_Exemplaire AS idExemplaire,
            E.Numero AS numero,
            E.Id_Emprunt

        FROM  Article as A,
              Exemplaire as E

        WHERE A.Id_Article = E.Id_Article) AS tab,
      [Format_article] AS F,
      [Genre] AS G
WHERE idGenre = G.Id_Genre

        AND idFormat = F.Id_Format
GROUP BY tab.nomArticle, 
		tab.idArticle, 
		F.Libelle_Format, 
		G.Libelle_Genre,
		tab.auteurs", GV_EMPRUNT);
        */
    }

    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);
        DataTable dt = (DataTable)Session["Usager"];
        Usager u = new Usager();
        DataRow[] result = dt.Select();
        foreach (DataRow row in result)
        {         
            acces = row["acces"].ToString();
        }  
        int_acces = Convert.ToInt32(acces);
        if (dt == null || int_acces != 0)
        {
            Response.Redirect("Connexion.aspx");
        }
    }
}