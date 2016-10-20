using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class profil : System.Web.UI.Page
{
    string chemin;
    protected void Page_Load(object sender, EventArgs e)
    {
       

           
            DataTable dt = (DataTable)Session["User"];
            DataRow[] resultUser = dt.Select();//on crée un tableau datarow où on met dt

            foreach (DataRow row in resultUser)
            {
                LB_NOM.Text = row["Nom"].ToString();
                //On met la ligne Nom
                LB_PRENOM.Text = row["Prenom"].ToString();
                LB_ADRESSE.Text = row["adresse"].ToString();
                LB_ACOMPLEMENT.Text = row["adresse_complement"].ToString();
                LB_CP.Text = row["code_postal"].ToString();
                LB_PAYS.Text = row["pays"].ToString();
                LB_TEL.Text = row["tel"].ToString();
                LB_MAIL.Text = row["email"].ToString();
                chemin="../images/"+row["nom_image"].ToString();

                String civilite = row["civilite"].ToString();
                if (civilite == "Madame")
                {
                    LB_MSG.Text = "Bienvenue Madame " + row["Nom"].ToString();
                }
                else
                {
                    LB_MSG.Text = "Bienvenu Monsieur " + row["Nom"].ToString();
                }

            }
              IMAGEBT1.ImageUrl = chemin;


    }

    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);
        DataTable dt = (DataTable)Session["User"];
        if (dt==null)
        {
            Response.Redirect("session.aspx");
        }
       
     }

    protected void BTN_MODIF_Click(object sender, EventArgs e)
    {
        Response.Redirect("Modif_profil.aspx");
    }
}
    

