using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Format
/// </summary>
public class Format
{
   public int id_format;
    public string libelle_format;
    public Format()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Format(int id, string libelle)
    {
        this.id_format = id;
        this.libelle_format = libelle;
    }
}