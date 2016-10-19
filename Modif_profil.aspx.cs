using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Windows;
public partial class Modif_profil : System.Web.UI.Page
{
    string pays;
    string civilite;
    String fileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        //on peut passer les valeurs dans des variables
        if (!IsPostBack)
        {

            DataTable dt = (DataTable)Session["User"];

            //on vérifie que la session existe toujours avant d'afficher la page profil
            if (dt == null)
            {
                Response.Redirect("session.aspx");
            }
        }

    }

    protected override void OnLoadComplete(EventArgs e)
    {
       
      
        DataTable dt = (DataTable)Session["User"];
        DataRow[] resultUser = dt.Select();//on crée un tableau datarow où on met dt

            foreach (DataRow row in resultUser)
            {
            //string IdPersonne;
            //IdPersonne = Int32.Parse(row["Id_Personne"].ToString());

                TXTB_NOM.Text = row["Nom"].ToString();
                civilite= row["civilite"].ToString();
           
                TXTB_PRENOM.Text = row["Prenom"].ToString();
                TXTB_ADRESSE.Text = row["adresse"].ToString();
                TXTB_ACOMPLEMENT.Text = row["adresse_complement"].ToString();
                TXTB_CP.Text=row["code_postal"].ToString();
                TXTB_VILLE.Text = row["ville"].ToString();
                pays=row["pays"].ToString();
                TXTB_TEL.Text = row["tel"].ToString();
                TXTB_MAIL.Text = row["email"].ToString();
            TXTB_MDP1.Text = row["MDP"].ToString();

            //on récupère le textbox en entier
            //txt_num ne peut pas être lu
           
        }

        if (!Page.IsPostBack) { 
            base.OnLoadComplete(e);
            DDL_PAYS.DataSource = Pays();
            DDL_PAYS.DataBind();
            DDL_PAYS.SelectedItem.Text = pays;
            DDL_CIVILITE.Text = civilite;

            }
        
    }

    protected override void OnInitComplete(EventArgs e)
    {
        if (!IsPostBack)
        {
            base.OnInitComplete(e);
            DataTable dt = (DataTable)Session["User"];
            if (dt == null)
            {
                Response.Redirect("session.aspx");
            }
        }
    }
    protected void BT_VALIDER_Click(object sender, EventArgs e)
    {
        //est-ce qu'on peut récupérer id_Personne?
      
        DataTable dt = (DataTable)Session["User"];

        //on vérifie que la session existe toujours avant d'afficher la page profil
        if (dt == null)
        {
            Response.Redirect("session.aspx");
        }
        else
        {

            Personne p = new Personne();
            p.civilite = DDL_CIVILITE.SelectedItem.Text;
            p.nom = TXTB_NOM.Text;
            p.prenom = TXTB_PRENOM.Text;
            
            User u = new User();
      
            u.email = TXTB_MAIL.Text;
            u.mdp = TXTB_MDP1.Text;

            Adresse a = new Adresse();
            a.adresse = TXTB_ADRESSE.Text;
            a.adresse_complement = TXTB_ACOMPLEMENT.Text;
            a.code_postal = TXTB_CP.Text.ToString();
            a.ville = TXTB_VILLE.Text;
            a.pays = DDL_PAYS.SelectedItem.Text;

            u.ModifProfil(p, u, a);

            DataTable newdt = u.selectionProfil(u.email, u.mdp);
            Session["User"] = newdt;
            Session["UserBack"] = newdt;
            Label1.Text = "La modification a bien été effectuée...";

        }

    }


    protected void TXTB_NOM_TextChanged(object sender, EventArgs e)
    {
        this.TXTB_NOM.Text = this.TXTB_NOM.Text.ToUpper();
        
    }
    public List<string> Pays()
    {
        List<string> ListePays = new List<string>();
        foreach (CultureInfo infos in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            RegionInfo region = new RegionInfo(infos.LCID);
            if (!ListePays.Contains(region.DisplayName))
            {
                ListePays.Add(region.DisplayName);
                ListePays.Sort();

            }

        }
        return ListePays;
    }

    protected void BTN_PARCOURIR_Click(object sender, EventArgs e)
    {

    }

    protected void FileUpload1_PreRender(object sender, EventArgs e)
    {
        
     
        
    }

    protected void FileUpload1_Load(object sender, EventArgs e)
    {
        
         
    }

    protected void BTN_UPLOAD_Click(object sender, EventArgs e)
    {
        // Specify the path on the server to
        // save the uploaded file to.
        String savePath = @"C:\inetpub\wwwroot\images\";

        // Before attempting to perform operations
        // on the file, verify that the FileUpload 
        // control contains a file.
        if (FileUpload1.HasFile)
        {
            // Get the name of the file to upload.
            fileName = FileUpload1.FileName;

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the 
            // uploaded file to the specified path.
            // This example does not perform all
            // the necessary error checking.               
            // If a file with the same name
            // already exists in the specified path,  
            // the uploaded file overwrites it.
            FileUpload1.SaveAs(savePath);

            // Notify the user of the name of the file
            // was saved under.
             //UploadStatusLabel.Text = "Your file was saved as " + fileName;
        }
        else
        {
            // Notify the user that a file was not uploaded.
            //UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
       
    

        User u = new User();
        u.email = TXTB_MAIL.Text;
        
        Image img = new Image();
        img.Id_Personne = 0;
        img.Id_image = 0;
        img.description_image = "";
        img.chemin_image = savePath;
        img.nom_image = fileName;
        //ajouter info image dans BDD
        img.AjouterImage(img,u);
        //display image
        IMGBT.ImageUrl = "../images/" + fileName;
        }
}

