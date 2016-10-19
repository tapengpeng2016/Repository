﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Session : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BTN_CONNECTER_Click(object sender, EventArgs e)
    {
        
        User u = new User();
        u.Id_user = 0;   
        u.email = TXTB_LOGIN.Text.ToString();
        u.mdp = TXTB_MDP.Text.ToString();

        int user_verif = u.KnownUser(u.email, u.mdp);
        DataTable dt = u.selectionProfil(u.email, u.mdp);
        Session["User"] = dt;
        if (user_verif==0)
        {
            LB_MSG.Text = "Vous n'êtes pas reconnu par le système";         
        } else {
           
               Response.Redirect("Espace_Usager.aspx");         
        }
       
    }

    protected void BTN_RECOVER_MDP_Click(object sender, EventArgs e)
    {

    }
}