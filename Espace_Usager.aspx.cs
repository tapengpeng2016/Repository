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
        DataRow[] dr = dt.Select();
        foreach (DataRow row in dr)
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
        }
    #endregion

    protected void BTN_ABONNEMNET_Click(object sender, EventArgs e)
    {
        PL_ABONNEMENT.Visible = true;
        PL_PROFIL.Visible = false;
        PL_EMPRUNT.Visible = false;
        PL_MDP.Visible = false;
       
    }

    protected void BTN_PROFIL_Click(object sender, EventArgs e)
    {
        PL_ABONNEMENT.Visible = false;
        PL_PROFIL.Visible = true;
        PL_EMPRUNT.Visible = false;
        PL_MDP.Visible = false;
    }
}
