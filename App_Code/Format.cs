using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Format
/// </summary>
public class Format
{
   public String id_format;
    public string libelle_format;
    public Format()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Format(string id, string libelle)
    {
        this.id_format = id;
        this.libelle_format = libelle;
    }
}