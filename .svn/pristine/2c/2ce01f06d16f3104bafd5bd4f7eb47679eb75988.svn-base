using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class crossarrivee : System.Web.UI.Page
{
    //on le fait pour la raison de sécurité, pour savoir d'ôù ça vient
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null)
        {
            //previous page dans historique
            Page p = Page.PreviousPage;
            //on récupère le textbox en entier
            //txt_num ne peut pas être lu
            ContentPlaceHolder cph = (ContentPlaceHolder)PreviousPage.Controls[0].FindControl("ContentPlaceHolder2");
            TextBox txt_num = (TextBox)cph.FindControl("txt_numero");
            LB_CARTE.Text = string.Format("Paiement à partir de la carte n°{0} XXXX XX{1}", txt_num.Text.Substring(0,4), txt_num.Text.Substring(14,2));

        }
    }
}