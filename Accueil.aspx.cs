using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accueil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    DataClassesDataContext db = new DataClassesDataContext();
    protected void BTN_SECONNECTER_Click(object sender, EventArgs e)
    {
        Usager usager = new Usager();
        try
        {
            usager = db.Usager.Single(p => p.mail == TXT_MAIL.Text);
            if (usager.motDePasse == TXT_MOTDEPASSE.Text)
            {
                Session["Usager"] = usager;
                if(usager.statut == 1)
                    Response.Redirect("EspaceGestionnaire.aspx");
                else
                    Response.Redirect("EspaceUsager.aspx");
            }
            else
            {
                // Maintenir le popup "modal" ouvert
                string jscript = "<script>$('#myModal').modal('show')</script>";
                System.Type t = this.GetType();
                ClientScript.RegisterStartupScript(t, "k", jscript);
                attention.Visible = true;
                LBL_ERREUR.Text = "Email ou mot de passe incorrect";
            }
        }
        catch
        {
            // Maintenir le popup "modal" ouvert
            string jscript = "<script>$('#myModal').modal('show')</script>";
            System.Type t = this.GetType();
            ClientScript.RegisterStartupScript(t, "k", jscript);
            attention.Visible = true;
            LBL_ERREUR.Text = "Email ou mot de passe incorrect";
        }
    }

    protected void BTN_CONNEXION_Click(object sender, EventArgs e)
    {
        
    }
}