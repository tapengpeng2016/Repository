﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accueil : System.Web.UI.Page
{
    int id_format;
    int id_genre;
    string libelle_format;
    string value;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Usager u = new Usager();
            u.RemplirGrid("SELECT * From [Article],[Format_article],[Genre] WHERE (Id_Article In (SELECT Id_Article From [Exemplaire] WHERE Id_Emprunt=0)) AND([Article].Id_Format=[Format_article].Id_Format) AND ([Article].Id_Genre=[Genre].Id_Genre);",GridView1);
          
            //DataTable dt =
            u.RecupérerValeurs("SELECT Id_Format,Libelle_Format FROM [Format_article];", DDL_FORMAT);
           // DataRow[] resultUser = dt.Select();//on crée un tableau datarow où on met dt
           
          /*  foreach (DataRow row in resultUser)
            {
                value = row["Id_Format"].ToString();
                libelle_format = row["Libelle_Format"].ToString();
                ListItem l = new ListItem(libelle_format,value);           
                DDL_FORMAT.Items.Add(l);
            }
            */
        }

    }

    protected void BTN_CONNEXION_Click(object sender, EventArgs e)
    {
        Response.Redirect("Connexion.aspx");
    }

    protected void DDL_FORMAT_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Label6.Text = DDL_FORMAT.SelectedIndex.ToString();
        Usager u = new Usager();
        id_format = Convert.ToInt32(DDL_FORMAT.SelectedValue);
        id_genre = Convert.ToInt32(DDL_GENRE.SelectedValue);
        if (id_format == 1&& id_genre == 0)
        {
            u.RemplirGrid("SELECT * From [Article],[Format_article],[Genre] WHERE (Id_Article In (SELECT Id_Article From [Exemplaire] WHERE Id_Emprunt=0)) AND([Article].Id_Format=[Format_article].Id_Format) AND ([Article].Id_Genre=[Genre].Id_Genre);",GridView1);
        }
        else
        {
            if (id_format!=1 && id_genre != 0)
            {
                u.RemplirGridGenreFormat(id_genre, id_format, GridView1);
            }else if(id_genre==0 && id_format!=1)
            {
                u.RemplirGrid(id_format, GridView1);
            }else
            {
                u.RemplirGridGenre(id_genre, GridView1);
            }        

        }
    }

    protected void DDL_GENRE_SelectedIndexChanged(object sender, EventArgs e)
    {
        Usager u = new Usager();

        id_format = Convert.ToInt32(DDL_FORMAT.SelectedValue);
        id_genre = Convert.ToInt32(DDL_GENRE.SelectedValue);
        if (id_format == 1 && id_genre == 0)
        {
            u.RemplirGrid("SELECT * From [Article],[Format_article],[Genre] WHERE (Id_Article In (SELECT Id_Article From [Exemplaire] WHERE Id_Emprunt=0)) AND([Article].Id_Format=[Format_article].Id_Format) AND ([Article].Id_Genre=[Genre].Id_Genre);",GridView1);
        }
        else
        {
            if (id_format != 1 && id_genre != 0)
            {
                u.RemplirGridGenreFormat(id_genre, id_format, GridView1);
            }
            else if (id_genre == 0 && id_format != 1)
            {
                u.RemplirGrid(id_format, GridView1);
            }
            else
            {
                u.RemplirGridGenre(id_genre, GridView1);
            }

        }
    }
}