using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Espace_Usager : System.Web.UI.Page
{
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        PL_EMPRUNT.Visible = false;
        User u = new User();
        str = @"SELECT * FROM[Article],[Format_article],[Genre],[Exemplaire],[Emprunt]
                WHERE[Emprunt].Id_Usager=3 AND([Article].Id_Format=[Format_article].Id_Format) AND([Article].Id_Genre=[Genre].Id_Genre) AND([Exemplaire].Id_Emprunt=[Emprunt].Id_Emprunt) AND([Exemplaire].Id_Article=[Article].Id_Article) AND[Exemplaire].Id_Exemplaire=[Emprunt].Id_Exemplaire;";
        u.RemplirGrid(str, GV_EMPRUNT);
           
    }

    protected void BTN_Emprunt_Click(object sender, EventArgs e)
    {
        PL_EMPRUNT.Visible = true;
    }
}