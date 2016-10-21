using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Reservation
/// </summary>
public class Reservation
{
    public int id_reservation;
    public int id_user;//usager
    public int id_exemplaire;
    public DateTime date_reservation;
    private string str = @"Data Source=DESKTOP-RPHGH20\SQLEXPRESS;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public Reservation()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region reserverEnligne
    public void Reserver()
    {
        //usager
        //admin
    }
    #endregion ModifierReservation
    public void ModifierReservation()
    {
        //usager
    }
    #region
    #endregion ConsulterReservation
    public DataTable Selection()
    {
        DataTable dt = new DataTable();
        using (SqlConnection cnx = new SqlConnection(str))
        {
            string strSqlCmd_Supprimer = @"SELECT R.[Id_Reservation], [Date_Reservation], A.[Nom], A.[Auteur], F.[Libelle_Format], G.[Libelle_Genre], X.[Numero]
                FROM [dbo].[Reservation] as R, 
	                    [dbo].[Article] as A, 
	                    [dbo].[Exemplaire] as X,
	                    [dbo].[Format_article] as F,
	                    [dbo].[Genre] as G
                WHERE R.Id_Reservation = @idReservation
                    AND R.Id_Exemplaire = X.Id_Exemplaire
                    AND X.Id_Article = A.Id_Article
                    AND A.Id_Format = F.Id_Format
                    AND A.Id_Genre = G.Id_Genre";
            SqlCommand SqlCmd = new SqlCommand(strSqlCmd_Supprimer, cnx);
            SqlCmd.Parameters.AddWithValue("@idReservation", this.id_reservation);
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);
            adapter.Fill(dt);
        }
        return dt;
    }
    public void ConsulterReservation()
    {
        //usager
        //admin

    }
    #region SupprimerReservation
    public string SupprimerReservation(int idReservation)
    {
        string info = "ERREUR";
        using (SqlConnection cnx = new SqlConnection(str))
        {
            cnx.Open();
            string strSqlCmd_Supprimer = @"DELETE FROM [dbo].[Reservation] WHERE Id_Reservation = @idReservation";
            SqlCommand SqlCmd_Supprimer = new SqlCommand(strSqlCmd_Supprimer, cnx);
            SqlCmd_Supprimer.Parameters.AddWithValue("@idReservation", idReservation);
            SqlCmd_Supprimer.ExecuteNonQuery();
            info = "Votre réservation est maintenant supprimée";
            cnx.Close();
        }
        return info;
    }
    #endregion
    #region Envoyer mail pour annoncer la dispo d'une réservation
    public void EnvoyerMail()
    {
        //admin
    }
    #endregion
    # region Transformer une réservation en emprunt
    public void TransformerEnEmprunt()
    {
        //admin
    }
    #endregion
    #region
    #endregion
}