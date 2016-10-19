using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class data_binding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //pour la première fois (avant de valider la formulaire)
        if (!Page.IsPostBack) {
            Label2.Text = "pas lié";
            //comme si on recharge la parge
            DropDownList2.AutoPostBack = true;
        }
                //indiquer la source
        DataList1.DataSource = DropDownList2.Items;
        //mettre à l'écoute de données, remplacé par page.databind
       // DataList1.DataBind();


        GridView1.DataSource = DropDownList2.Items;
        //GridView1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //page.databind--pour mettre tous les composants à l'écoute. 
        Page.DataBind();
        Label2.Text = DropDownList2.SelectedValue;
        Label4.Text = DropDownList2.SelectedIndex.ToString();
    }
    protected string MiseALHeure()
    {
        DateTime dt = DateTime.Now;
        string sd = dt.ToLongDateString();
        string st = dt.ToLongTimeString();

        return sd.ToString()+" "+st.ToString();
    }
}