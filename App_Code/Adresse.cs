﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Adresse
/// </summary>
public class Adresse
{
    //this is a test
    public int Id_adresse;
    public int Id_personne;
    public string adresse;
    public string adresse_complement;
    public string code_postal;
    public string ville;
    public string pays;

    private string str = "REPOSITORY";

    //private string str = "Data Source=DESKTOP-10VV38I;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //private string str = "Data Source=DESKTOP-L80VGMJ;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    public Adresse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void EnregistrerInscription(Adresse a)
    {
       

        SqlConnection cnx = new SqlConnection(str);
        cnx.Open();
       
        string sql0 = "SELECT Id_Personne FROM [Adresse] WHERE adresse='" + a.adresse+"', code_postal="+a.code_postal;
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        int adresseExistant;
        try
        {
            adresseExistant = Convert.ToInt32(cmd0.ExecuteScalar());

        }
        catch (Exception)
        {
            adresseExistant = -1;
        }

        cnx.Close();
        if (adresseExistant == -1)
        {
            //choisir le dernier Id_Adresse
            cnx.Open();
            string sql = "SELECT TOP 1 Id_Adresse FROM [dbo].[Adresse] order by Id_Adresse DESC";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.CommandType = CommandType.Text;
            int id1 = Convert.ToInt32(cmd.ExecuteScalar());
            cnx.Close();
            int id_adresse = id1 + 1;

            //choisir le dernier Id_Personne
            cnx.Open();
            string sql3 = "SELECT TOP 1 Id_Personne FROM [dbo].[Personne] order by Id_Personne DESC";
            SqlCommand cmd3 = new SqlCommand(sql3, cnx);
            cmd3.CommandType = CommandType.Text;
            int id_personne = Convert.ToInt32(cmd3.ExecuteScalar());
            cnx.Close();
           

            //Insérer les infos dans [User]
            cnx.Open();
            string sql1 = "INSERT INTO [Adresse](Id_Adresse,Id_Personne,adresse,adresse_complement,code_postal,ville,pays) VALUES('" + id_adresse + "','" + id_personne + "','" +a.adresse + "','" + a.adresse_complement + "','" + a.code_postal + "', '" + a.ville + "','" + a.pays + "')";
            SqlCommand cmd1 = new SqlCommand(sql1, cnx);
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            cnx.Close();


        }
        else
        {

            cnx.Open();
            string sql2 = "UPDATE [Adresse] SET adresse='" + a.adresse + "', adresse_complement='"+a.adresse_complement+"', code_postal='"+a.code_postal+"', ville='"+a.ville+"', pays='"+a.pays+"' WHERE Id_Personne=" + adresseExistant;
            SqlCommand cmd2 = new SqlCommand(sql2, cnx);
            cmd2.CommandType = CommandType.Text;
            cmd2.ExecuteNonQuery();
            cnx.Close();
        }



    }
}