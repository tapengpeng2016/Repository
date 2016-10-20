using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Emprunt
/// </summary>
public class Emprunt
{
    public int id_emprunt;
    public int id_user;//usager
    public int id_exemplaire;
    public DateTime dateRetourEstimee;
    public DateTime dateRetourReelle;
    public DateTime dateEmprunt;
    public Emprunt()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region CreerEmprunt
    public void CreerEmprunt()
    {
        //admin
    }

    #endregion
    #region ModifierEmprunt
    public void ModifierEmprunt()
    {
        //admin
    }
    #endregion
    #region SupprimerEmprunt
    public void SupprimerEmprunt()
    {
        //admin
    }

    #endregion


}