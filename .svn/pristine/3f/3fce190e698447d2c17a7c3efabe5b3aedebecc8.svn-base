using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestionEvenements : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //1er event
        if (!IsPostBack)
        {
            ListBox1.Items.Add("Nîmes");
            ListBox1.Items.Add("Hyères");
            ListBox1.Items.Add("Porquerolles");
           
        }
        //appelée uniquement si AutoEventWriteUp=true;
        Label1.Text += "Dans Page_load<br>";


    }
    //2nd event
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Label1.Text += "Dans OnLoad<br>";

    }
    //3rd event
    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);
        Label1.Text += "Dans OnLoadComplete<br>";
    }

    protected void ListBox1_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListBox1.Items.Add("Marseille");
        }
        Label1.Text += "Ajouter Marseille";
    }

    //pré-chargement
    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);
        Label1.Text += "OnInitComplete";
    }
}