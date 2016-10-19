using System;
using System.Collections.Generic;
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
    public void ConsulterReservation()
    {
        //usager
        //admin

    }
    #region SupprimerReservation
    public void SupprimerReservation()
    {
        //usager

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