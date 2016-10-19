using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class NameSpace : System.Web.UI.Page
{
    const string nomFichier = "Compteur.data";
    private string nomRep = "Repdata";
    private string nomFichier1 = "";
    const string repertoire = "Compteur";
    const string nameFile = "NumRecord.txt";
    const string pageHTML = "\\TexteRecord.html";
    protected void Page_Load(object sender, EventArgs e)
    {
        Init_Fichier();
        //créer HTML
        string pathAppli = Page.MapPath(".");
        nomFichier1 = pathAppli + "\\" + repertoire +pageHTML ;
        File.WriteAllText(nomFichier1,"<h>Hello World</h>");
    }
    private void Init_Fichier()
    {
        //donne le chemin d'accès physique de la page
        string pathAppli = Page.MapPath(".");

        //création du répertoire s'il n'existe pas(un dossier)      
        string nomRep1 = "";
        nomRep1 = pathAppli + "\\" + repertoire;
        if (!Directory.Exists(nomRep))
        {
            Directory.CreateDirectory(nomRep1);

        }

        //création du fichier s'il n'existe pas
        //dans windows, si on ne donne pas de .txt, il n'affichera pas
       
        string nameFile2 = "";
        nameFile2 = nomRep1 + "\\" + nameFile;
        if (!File.Exists(nameFile2))
        {
            FileStream fichier = new FileStream(nameFile2, FileMode.CreateNew);
            fichier.WriteByte(0);
            fichier.Close();

        }

    }

    private int Comptabilise()
    {
        //Donne le chemin d'accès physique de la page
        string pathAppli = Page.MapPath(".");
        
        nomFichier1 = pathAppli + "\\" + repertoire + "\\" + nameFile;

        FileStream fichier = new FileStream(nomFichier1, FileMode.Open);//ouverture du fichier;
        int cpt = fichier.ReadByte();
        cpt++;//lecture de l'octet

        fichier.Seek(0, SeekOrigin.Begin);//après la lecture, on remet à la postion 0
        fichier.WriteByte((byte)cpt);//écriture après casting de l'entier en octet
        fichier.Close();

        return cpt;
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        int cpt=Comptabilise();
        
        TextBox1.Text = cpt.ToString();
    }
}