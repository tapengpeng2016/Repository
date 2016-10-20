using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Espace_Usager : System.Web.UI.Page
{
    //
    string str;
    string usager;
    string mdp;
    string mdp1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //récupérer Id_Usager
        Usager u = new Usager();
        DataTable dt = (DataTable)Session["Usager"];
        foreach (DataRow row in dt.Rows)
        {
            usager = row["Id_Usager"].ToString();
        }
        u.Id_usager = Convert.ToInt32(usager);

        //Emprunt
        PL_EMPRUNT.Visible = false;
        u.ConsulterEmprunt(u.Id_usager, GV_EMPRUNT);

        //Profil Usager
        //Abonnement
        DataTable infoUsager = u.SelectionInfoUsager(u.Id_usager);
        DataRow[] Usager = infoUsager.Select();
        foreach (DataRow row in Usager)
        {
            TXTB_NOM.Text = row["Nom"].ToString();
            TXTB_PRENOM.Text = row["Prenom"].ToString();
            TXTB_MAIL.Text = row["Identifiant"].ToString();
           // TXTB_MDP.Text = row["mdp"].ToString();
            LB_DATEABONNEMENT.Text =row["Date_Abonnement"].ToString();
            LB_TARIF.Text = row["Tarif"].ToString();
            LB_TYPE.Text = row["Type"].ToString();
          
        }

       
       
    }
    protected void BTN_Emprunt_Click(object sender, EventArgs e)
    {
        PL_EMPRUNT.Visible = true;
        PL_ABONNEMENT.Visible = false;
        PL_PROFIL.Visible = false;
        PL_MDP.Visible = false;
    }
    protected override void OnInitComplete(EventArgs e)
    {
        DataTable dt = (DataTable)Session["Usager"];
        if (dt == null)
        {
            Response.Redirect("Connexion.aspx");
        }
        base.OnInitComplete(e);
    }
    protected void BTN_DECONNEXION_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Connexion.aspx");
    }
    protected void TXTB_NOM_TextChanged(object sender, EventArgs e)
    {
        this.TXTB_NOM.Text = this.TXTB_NOM.Text.ToUpper();
    }
    protected void BT_VALIDER_Click(object sender, EventArgs e)
    {
       
    }
    

    protected void BTN_MODIF_MDP_Click(object sender, EventArgs e)
    {
        PL_ABONNEMENT.Visible = false;
        PL_PROFIL.Visible = true;
        PL_EMPRUNT.Visible = false;
        PL_MDP.Visible = true;
    }

    #region Modifier MDP
    protected void BTN_VALIDERMDP_Click(object sender, EventArgs e)
    {
        
            DataTable dt = (DataTable)Session["Usager"];
            Usager u = new Usager();            
            DataRow[] result = dt.Select();
            foreach (DataRow row in result)
            {
                usager = row["Id_Usager"].ToString();
            }
            u.Id_usager = Convert.ToInt32(usager);

            DataTable infoUsager = u.SelectionInfoUsager(u.Id_usager);
            DataRow[] result_info = infoUsager.Select();
            foreach (DataRow row in result_info)
            {
                mdp = row["mdp"].ToString();
            }
            
        if (TXTB_ANCIENMDP.Text.ToString() == mdp)
            {
                //enregistrement de nouveau mdp
                u.ModifierMDP(u.Id_usager, TXTB_NEWMDP1.Text.ToString());
                //récupéter la nouvelle session
                DataTable infoUsager1 = u.SelectionInfoUsager(u.Id_usager);
                DataRow[] Usager1 = infoUsager1.Select();
                foreach (DataRow row in Usager1)
                {
                    usager = row["Id_Usager"].ToString();
                    mdp1 = row["mdp"].ToString();
                }
            LB_MSG.Text = "Votre mot de passe a bien été modifié";
           
            }
            else
            {
                LB_MSG.Text = "Mot de passe incorrecte. Veuillez réessayer...";
            }
<<<<<<< HEAD
        }
    #endregion

    protected void BTN_ABONNEMNET_Click(object sender, EventArgs e)
=======
        } 
    }
    protected void BTN_MODIF_MDP_Click(object sender, EventArgs e)
>>>>>>> origin/master
    {
        PL_ABONNEMENT.Visible = true;
        PL_PROFIL.Visible = false;
        PL_EMPRUNT.Visible = false;
        PL_MDP.Visible = false;
       
    }
<<<<<<< HEAD

    protected void BTN_PROFIL_Click(object sender, EventArgs e)
=======
    protected void BTN_VALIDERMDP_Click(object sender, EventArgs e)
>>>>>>> origin/master
    {
        PL_ABONNEMENT.Visible = false;
        PL_PROFIL.Visible = true;
        PL_EMPRUNT.Visible = false;
        PL_MDP.Visible = false;
    }
    protected void GV_ACCUEIL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idArticle =
        (int)GV_ACCEUIL.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
        PL_RE.Visible = true;
        LB_IDARTICLE.Text = idArticle.ToString();
        Article a = new Article();
        a.id_article = idArticle;
        a.Selection();
        LB_NOMARTICLE.Text = a.nom;
        LB_AUTEUR.Text = a.auteur;
        if (a.Disponible())
        {
            BTN_RESERVER.Visible = false;
            BTN_EMPRUNTER.Visible = true;
        }
        else
        {
            BTN_EMPRUNTER.Visible = false;
            BTN_RESERVER.Visible = true;
        }
    }
    protected void BTN_RESERVER_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Usager"];
            Usager u = new Usager();
            int idUsager = 0;
            foreach (DataRow row in dt.Rows)
            {
                idUsager = int.Parse(row["Id_Usager"].ToString());
                LB_NOMARTICLE.Text += idUsager.ToString();
            }
            if (idUsager != 0) { u.ReserverArticle(idUsager, int.Parse(LB_IDARTICLE.Text)); LB_NOMARTICLE.Text += "ERREUR"; };
        }
        catch
        {
            //LB_NOMARTICLE.Text += "ERREUR" ;
        }
    }
    protected void BTN_EMPRUNTER_Click(object sender, EventArgs e)
    {

    }
}
