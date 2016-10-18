using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Image
/// </summary>
public class Image
{
    public int Id_image;
    public int Id_Personne;
    public string nom_image;
    public string description_image;
    public string chemin_image;
    private string str = "REPOSITORY";
    //private string str = "Data Source=DESKTOP-10VV38I;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //private string str = "Data Source=DESKTOP-L80VGMJ;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    SqlConnection cnx;
    public Image()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int RecupererImage(Image i, User u)
    {
        cnx = new SqlConnection(str);

        cnx.Open();
        string sql0 = "SELECT Id_Personne FROM [dbo].[User] WHERE email='" + u.email + "'";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        int id_personne = Convert.ToInt32(cmd0.ExecuteScalar());
        cnx.Close();

        return id_personne;
    }

    public void AjouterImage(Image i, User u)
    {
        cnx = new SqlConnection(str);

        cnx.Open();
        string sql0 = "SELECT Id_Personne FROM [dbo].[User] WHERE email='" + u.email + "'";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        int id_personne = Convert.ToInt32(cmd0.ExecuteScalar());
        cnx.Close();
        
        cnx.Open();
        string sql2 = "SELECT COUNT(*) Id_Personne FROM [dbo].[Image] WHERE Id_Personne="+id_personne;
        SqlCommand cmd2 = new SqlCommand(sql2, cnx);
        cmd2.CommandType = CommandType.Text;
        int count = Convert.ToInt32(cmd2.ExecuteScalar());
        cnx.Close();

        if (count != 0) { 
        cnx.Open();
        string sql3 = "UPDATE [dbo].[Image] SET nom_image='" + i.nom_image+ "', description_image='" + i.description_image + "',chemin_image='" + i.chemin_image + "' WHERE Id_Personne=" + id_personne;
        SqlCommand cmd3 = new SqlCommand(sql3, cnx);
        cmd3.CommandType = CommandType.Text;
        cmd3.ExecuteNonQuery();
        cnx.Close();
        }else
        {
            cnx.Open();
            string sql4 = "SELECT TOP 1 Id_Image FROM [dbo].[Image] order by Id_Image DESC";
            SqlCommand cmd4 = new SqlCommand(sql4, cnx);
            cmd4.CommandType = CommandType.Text;
            int id_img = Convert.ToInt32(cmd4.ExecuteScalar());
            id_img += 1;
            cnx.Close();

            cnx.Open();
            string sql1 = "INSERT INTO [Image](Id_Image, Id_Personne, nom_image, description_image, chemin_image) VALUES('" + id_img + "','" + id_personne + "','" + i.nom_image + "', '" +i.description_image+"','"+ i.chemin_image+ "')";
            SqlCommand cmd1 = new SqlCommand(sql1, cnx);
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            cnx.Close();
        }
        
    }

}