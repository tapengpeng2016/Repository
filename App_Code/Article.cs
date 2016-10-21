using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Article
/// </summary>
public class Article
{
    public int id_article;
    public string nom;
    public int id_format;
    public int id_genre;
    public string auteur;
    //private string str = "Data Source=DESKTOP-10VV38I;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //private string str = "Data Source=DESKTOP-L80VGMJ;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    private string str = @"Data Source=DESKTOP-RPHGH20\SQLEXPRESS;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public Article()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region
    
    #endregion
    public void Selection()
    {
        DataTable dt = new DataTable();
        SqlConnection cnx = new SqlConnection(str);
        cnx.Open();
        string sql0 = "SELECT * FROM [Article] WHERE Id_Article=@idArticle";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.AddWithValue("@idArticle", this.id_article);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd0);
        adapter.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            this.nom = (string)row["Nom"];
            this.auteur = (string)row["Auteur"];
        }
        cnx.Close();
    }
    public bool Disponible()
    {
        bool success = false;
        using (SqlConnection cnx = new SqlConnection(str))
        {
            cnx.Open();

            string strSqlCmd_GetExemplaire = @"SELECT Count(*)
                                                FROM [dbo].[Exemplaire] as X
                                               WHERE X.Id_Article = @idArticle
                                                    AND X.Id_Emprunt = 0";
            SqlCommand SqlCmd_GetExemplaire = new SqlCommand(strSqlCmd_GetExemplaire, cnx);
            SqlCmd_GetExemplaire.Parameters.AddWithValue("@idArticle", this.id_article);
            int NbrExemplaire = int.Parse(SqlCmd_GetExemplaire.ExecuteScalar().ToString());
            if (NbrExemplaire > 0) { success = true; } else { success = false; }
            cnx.Close();
        }
        return success;
    }
}