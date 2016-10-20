using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Connexion : System.Web.UI.Page
{
    string usager;
    string acces;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BTN_CONNECTER_Click(object sender, EventArgs e)
    {
        Usager u = new Usager();
        u.Id_usager = 0;   
        u.email = TXTB_LOGIN.Text.ToString();
        u.mdp = TXTB_MDP.Text.ToString();

        int user_verif = u.KnownUser(u.email, u.mdp);
        DataTable dt = u.selectionProfil(u.email, u.mdp);
        DataRow[] result = dt.Select();
        Session["Usager"] = dt;
        if (user_verif==0)
        {
            LB_MSG.Text = "Vous n'êtes pas reconnu par le système";         
        } else {
            foreach (DataRow row in result)
            {
                acces = row["acces"].ToString();
            }
            int i_acces = Convert.ToInt32(acces);
            if(i_acces==0)
            {
                Response.Redirect("Espace_Gestionnaire.aspx");
            }
             else
                Response.Redirect("Espace_Usager.aspx");         
        }
       
    }

    protected void BTN_RECOVER_MDP_Click(object sender, EventArgs e)
    {

    }
}