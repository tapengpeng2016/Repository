using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Espace_Gestionnaire : System.Web.UI.Page
{
    string usager;
    string acces;
    int int_acces;
    List<string> list;
    protected void Page_Load(object sender, EventArgs e)
    {
        Gestionnaire g = new Gestionnaire();
        g.TousUsager(GV_USAGERS);
        

    }

    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);
        DataTable dt = (DataTable)Session["Usager"];
        Usager u = new Usager();
        DataRow[] result = dt.Select();
        foreach (DataRow row in result)
        {         
            acces = row["acces"].ToString();
        }  
        int_acces = Convert.ToInt32(acces);
        if (dt == null || int_acces != 0)
        {
            Response.Redirect("Connexion.aspx");
        }
    }


    protected void TXTB_RECHERCHEID_TextChanged(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(TXTB_RECHERCHEID.Text.Trim()) == false)
        {
            /*
             foreach (string str in list)
             {
                 if (str.StartsWith(TXTB_RECHERCHEID.Text.Trim()))

                 {
                     lb1.Items.Add(str);
                 }
             }
         }

         else if (TXTB_RECHERCHEID.Text.Trim() == "")
         {
             lb1.Items.Clear();

             foreach (string str in list)
             {
                 lb1.Items.Add(str);
             }
         }*/
        }
    }
}