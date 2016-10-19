﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Espace_Usager : System.Web.UI.Page
{
    string str;
    string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = new User();
        DataTable dt = (DataTable)Session["User"];
        DataRow[] dr = dt.Select();
        foreach(DataRow row in dr)
        {
            user= row["Id_Usager"].ToString();
        }
        u.Id_user = Convert.ToInt32(user);
        //Label5.Text = user;
        PL_EMPRUNT.Visible = false;
        u.ConsulterEmprunt(u.Id_user,GV_EMPRUNT);  
           
    }

    protected void BTN_Emprunt_Click(object sender, EventArgs e)
    {
        PL_EMPRUNT.Visible = true;
    }
    protected override void OnInitComplete(EventArgs e)
    {
        DataTable dt = (DataTable)Session["User"];
        if (dt == null)
        {
            Response.Redirect("Connexion.aspx");
        }
        base.OnInitComplete(e);
    }

    protected void BTN_DECONNEXION_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Connexion.aspx");
    }
}