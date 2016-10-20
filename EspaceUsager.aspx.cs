using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EspaceUsager : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        if(Session["Usager"] == null) { Response.Redirect("Accueil.aspx"); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Usager usager = new Usager();
        usager = (Usager)Session["Usager"];
        PL_ACCUEIL.Visible = true;
        PL_ABONNEMENT.Visible = false;
        PL_EMPRUNT.Visible = false;
        PL_RESERVATION.Visible = false;
        LB_USAGER.Text = usager.nom + " " + usager.prenom + "(" + usager.mail + ")";
    }

    protected void LBTN_RESERVATION_Click(object sender, EventArgs e)
    {
        PL_RESERVATION.Visible = true;
        PL_ACCUEIL.Visible = false;
        //SqlDataSource sqlDataSource_Reservation = new SqlDataSource();
        //sqlDataSource_Reservation.ConnectionString = @"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=MEDIATHEQUES;Integrated Security=True";
        //sqlDataSource_Reservation.SelectCommand = @"";
        //GV_RESERVATION.DataSource = sqlDataSource_Reservation;
        //GV_RESERVATION.DataBind();
    }

    protected void LBTN_EMPRUNT_Click(object sender, EventArgs e)
    {
        PL_EMPRUNT.Visible = true;
        PL_ACCUEIL.Visible = false;
        //SqlDataSource sqlDataSource_Emprunt = new SqlDataSource();
        //sqlDataSource_Emprunt.ConnectionString = @"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=MEDIATHEQUES;Integrated Security=True";
        //sqlDataSource_Emprunt.SelectCommand = @"";
        //GV_EMPRUNT.DataSource = sqlDataSource_Emprunt;
        //GV_EMPRUNT.DataBind();
    }

    protected void LBTN_ABONNEMENT_Click(object sender, EventArgs e)
    {
        PL_ABONNEMENT.Visible = true;
        PL_ACCUEIL.Visible = false;
    }

    protected void LBTN_ACCUEIL_Click(object sender, EventArgs e)
    {
        PL_ACCUEIL.Visible = true;
        GV_ACCUEIL.DataBind();
        GV_ACCUEIL.UseAccessibleHeader = true;
        GV_ACCUEIL.HeaderRow.TableSection = TableRowSection.TableHeader;
        //SqlDataSource sqlDataSource_Accueil = new SqlDataSource();
        //sqlDataSource_Accueil.ConnectionString = @"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=MEDIATHEQUES;Integrated Security=True";
        //sqlDataSource_Accueil.SelectCommand = @"";
        //GV_ACCUEIL.DataSource = sqlDataSource_Accueil;
        //GV_ACCUEIL.DataBind();
    }

    protected void LBTN_DECONNEXION_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Accueil.aspx");
    }
    DataClassesDataContext db = new DataClassesDataContext();
    protected void DDL_GENRE_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_ACCUEIL.DataBind();
    }
    protected void GV_Accueil_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            int idArticle =
            (int)GV_ACCUEIL.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
            Article article = new Article();
            article = db.Article.Single(x => x.idArticle == idArticle);
            // Maintenir le popup "modal" ouvert
            string jscript = "<script>$('#myModalAccueil').modal('show')</script>";
            System.Type t = this.GetType();
            ClientScript.RegisterStartupScript(t, "k", jscript);
            LB_NOMARTICLE.Text = article.nom;
        SqlDataSource1.FilterExpression = "";
    }

    protected void GV_ACCUEIL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}