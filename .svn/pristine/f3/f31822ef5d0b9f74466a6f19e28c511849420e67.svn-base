using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class arrivee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null)
        {
            //previous page dans historique
            Page p = Page.PreviousPage;
            //on récupère le textbox en entier
            TextBox txt_num = p.FindControl("txt_numero") as TextBox;
            LB_CARTE.Text = string.Format("Paiement à partir de la carte n°{0} XXXX XX{1}", txt_num.Text.Substring(0, 4), txt_num.Text.Substring(14, 2));

        }

    }
}