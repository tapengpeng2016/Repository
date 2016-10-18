using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjoutDynamiqueControles : System.Web.UI.Page
{
    private Button b;
    private HyperLink b1;
    private Button cmd;
    private Label LB_M;
    //private Panel panel;
    private ContentPlaceHolder cph;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //  Panel panel = new Panel();
        // ContentPlaceHolder cph = new ContentPlaceHolder();
        // Page.Controls.Add(cph);
        // cph.Controls.Add(panel);
        Response.Write("<style>.btn{background-color: grey; font-size: white;}</style>");

        //rechercher en BDD, liste de rubriques
        string[] tab = new string[10];

        tab[0] = "Inscription";
        tab[1] = "Default";
        tab[2] = "NameSpace";
        tab[3] = "Accueil";

        //menu de navigateur
        for (int i = 0; i < 10; i++)
        {
            b1 = new HyperLink();
            b1.CssClass = "btn";
            b1.Text = tab[i];
            b1.ID = "link "+i;
            b1.NavigateUrl =tab[i]+".aspx";
            
            
            panel1.Controls.Add(b1);
        }
        //créaction  de label
        LB_M = new Label();
        LB_M.ID = "LB_M";
        panel1.Controls.Add(LB_M);

        //créaction dynamique du button
        b = new Button();
        b.Text = "cliquer ici";
        b.ID = "button";
        panel1.Controls.Add(b);
        b.Click += new EventHandler(b_Click);

        //créaction dynamique du button
        cmd = new Button();
        cmd.Text = "cliquer aqui";
        cmd.ID = "cmd";
        panel1.Controls.Add(cmd);
        
        cmd.Click += new EventHandler(traiter_click);
    }

    void b_Click(object sender, EventArgs e)
    {
      
        LB_M.Text = "Nouveau Clic";
    }
    void traiter_click(object sender, EventArgs e)
    {
        LB_M.Text = "Encore un clic";
    }
}