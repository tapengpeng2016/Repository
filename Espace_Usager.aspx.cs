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
        DataTable infoUsager = u.SelectionInfoUsager(u.Id_usager);
        DataRow[] Usager = infoUsager.Select();
        foreach (DataRow row in Usager)
        {
            TXTB_NOM.Text = row["Nom"].ToString();
            TXTB_PRENOM.Text = row["Prenom"].ToString();
            TXTB_MAIL.Text = row["Identifiant"].ToString();
            TXTB_MDP.Text = row["mdp"].ToString();
        }
        Label5.Text = TXTB_MDP.Text;

    }
    protected void BTN_Emprunt_Click(object sender, EventArgs e)
    {
        PL_EMPRUNT.Visible = true;
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
        DataTable dt = (DataTable)Session["Usager"];
        if (dt == null)
        {
            Response.Redirect("Connexion.aspx");
        }
        else
        {
            Usager u = new Usager();
            DataTable infoUsager = u.SelectionInfoUsager(u.Id_usager);
            DataRow[] Usager = infoUsager.Select();
            foreach (DataRow row in Usager)
            {
                usager = row["Id_Usager"].ToString();         
                mdp = row["mdp"].ToString();
            }
            u.Id_usager = Convert.ToInt32(usager);
            if (TXTB_ANCIENMDP.Text == mdp)
            {
                //enregistrement de nouveau mdp
                u.ModifierMDP(u.Id_usager,TXTB_NEWMDP1.Text.ToString());

                //récupéter la nouvelle session
                DataTable infoUsager1 = u.SelectionInfoUsager(u.Id_usager);
                DataRow[] Usager1 = infoUsager.Select();
                foreach (DataRow row in Usager1)
                {
                    usager = row["Id_Usager"].ToString();
                    mdp1 = row["mdp"].ToString();
                }
                LB_MSG.Text = mdp1;
            }
            else
            {
                LB_MSG.Text = "Mot de passe incorrecte";
            }
        } 
    }
    protected void BTN_MODIF_MDP_Click(object sender, EventArgs e)
    {
        PL_MDP.Visible = true;
    }
    protected void BTN_VALIDERMDP_Click(object sender, EventArgs e)
    {

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
        LB_IDARTICLE.Text = a.id_article.ToString();
        if (a.Disponible())
        {
            LB_DISPONIBLE.Text = "Cette Article est disponible à l'emprunt. RDV à la Médiathèque.";
            BTN_RESERVER.Visible = false;
        }
        else
        {
            LB_DISPONIBLE.Text = "";
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
                //LB_NOMARTICLE.Text += "<br/> Id_usager : " + idUsager.ToString() + " ---- IdArticle :" + int.Parse(LB_IDARTICLE.Text) + "<br/>";
            }
            if (idUsager != 0) {
                string info = u.Reserver(idUsager, int.Parse(LB_IDARTICLE.Text));
                LB_NOMARTICLE.Text += "<br/>" + info + "<br/>";
                BTN_RESERVER.Visible = false;
                GV_RESERVATION.DataBind();
                GV_ACCEUIL.DataBind();
            }
        }
        catch
        {
            LB_NOMARTICLE.Text += "ERREUR";
        }
    }
    protected void BTN_RESERVATION_Click(object sender, EventArgs e)
    {
        PL_RESERVATION.Visible = true;
        //récupérer Id_Usager
        Usager u = new Usager();
        DataTable dt = (DataTable)Session["Usager"];
        foreach (DataRow row in dt.Rows)
        {
            usager = row["Id_Usager"].ToString();
        }
        u.Id_usager = Convert.ToInt32(usager);
        string sql = @"SELECT* FROM[dbo].[Reservation] as R, [dbo].[Article] as A, [dbo].[Exemplaire] as X
WHERE R.Id_Exemplaire = X.Id_Exemplaire AND X.Id_Article = A.Id_Article And R.Id_Usager = " + u.Id_usager   +" ;";
        SqlDataSource3.SelectCommand = sql;
    }

    protected void GV_ACCEUIL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_RESERVATION_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idReservation = (int)GV_RESERVATION.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
        PL_RE.Visible = true;
        LB_IDARTICLE.Text = idReservation.ToString();
        Reservation reservation = new Reservation();
        reservation.id_reservation = idReservation;
        DataTable dt = new DataTable();
        dt = reservation.Selection();
        foreach (DataRow row in dt.Rows)
        {
            LB_IDRESERVATION.Text = idReservation.ToString();
            LB_SELECTIONRESERVATION.Text = "Annuler votre réservation effectuée le " 
                                                + DateTime.Parse(row["Date_Reservation"].ToString()).ToShortDateString() 
                                                + ", de l'article '"
                                                + (string)row["Nom"] + "'(" + (string)row["Auteur"] + ")"
                                                + ", " + (string)row["Libelle_Format"] + " - " + (string)row["Libelle_Genre"]
                                                + ", numéro de l'exemplaire : " + ((int)row["Numero"]).ToString();
        }
        PL_SUPPRIMER.Visible = true;
    }

    protected void BTN_SUPPRIMERRESERVATION_Click(object sender, EventArgs e)
    {
        Reservation reservation = new Reservation();
        reservation.SupprimerReservation(int.Parse(LB_IDRESERVATION.Text));
        PL_SUPPRIMER.Visible = false;
        GV_RESERVATION.DataBind();
    }

    protected void LB_FERMER_RESERVATION_Click(object sender, EventArgs e)
    {
        PL_RESERVATION.Visible = false;
    }
}
