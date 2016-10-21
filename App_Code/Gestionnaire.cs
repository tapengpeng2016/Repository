using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Description résumée de Gestionnaire
/// </summary>
public class Gestionnaire
{
    private string str = "Data Source=DESKTOP-10VV38I;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //private string str = "Data Source=DESKTOP-L80VGMJ;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    // private string str = @"Data Source=DESKTOP-RPHGH20\SQLEXPRESS;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    public static SqlCommand cmd_1;
    public static SqlDataReader dr;
    public static DataTable dt;
    SqlConnection cnx;

    public Gestionnaire()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region TousUsagers
    public void TousUsager(GridView g)
    {
        cnx = new SqlConnection(str);
        DataTable dt = new DataTable();
        cnx.Open();
        string sql0 = "SELECT * FROM [dbo].[Usager],[Abonnement],[Tarif] WHERE [Abonnement].Id_Usager=[Usager].Id_Usager AND [Abonnement].Id_Tarif=[Tarif].Id_Tarif";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        dr=cmd0.ExecuteReader();
        dt.Load(dr);
        g.DataSource= dt;
        g.DataBind();
        cnx.Close();
     
    }
    #endregion
}