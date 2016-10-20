using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Navigation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //differents méthodes pour la navigation, Execute et transfer sont les plus sûres
        //1er: on voit tout le lien dès qu'on passe dessus
        string nom_produit = "Livres";
        int id_produit = 34;
        HyperLink1.Text = "Produit " + nom_produit;
        HyperLink1.NavigateUrl = string.Format("Acceuil.aspx?id_produit={0}", id_produit);
    }

    //2nd
    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Execute("Acceuil.aspx");
    }

    //3rd: sécurisé
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "wang" && TextBox2.Text == "dawei")
            Response.Redirect("Acceuil.aspx");
    }

    //4eme: sécurisé
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Acceuil.aspx");
    }
}