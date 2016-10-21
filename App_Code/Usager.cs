using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Personne s'est incrit en ligne
/// 2 statuts: en attente ou confirmation inscription
/// </summary>

//classe Usager
public class Usager
{
    public int Id_usager;
    public int acces;
    public string nom;
    public string prenom;
    public DateTime dateNaissance;
    public string email; //=identifiant
    public string mdp;
    
    //private string str = "REPOSITORY";
    private string st;
    //private string str = "Data Source=DESKTOP-10VV38I;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //private string str = "Data Source=DESKTOP-L80VGMJ;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    private string str = @"Data Source=DESKTOP-RPHGH20\SQLEXPRESS;Initial Catalog=Inscription;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    public static SqlCommand cmd_1;
    public static SqlDataReader dr;
    public static DataTable dt;
    SqlConnection cnx;

    public Usager()
    {
       
    }

    #region enregistrerInscription- A modifier
    public void EnregistrerInscription(Usager u)
    {
       cnx= new SqlConnection(str);

        //choisir le dernier Id_User
        cnx.Open();
            string sql = "SELECT TOP 1 Id_User FROM [dbo].[User] order by Id_User DESC";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.CommandType = CommandType.Text;
            int id1 = Convert.ToInt32(cmd.ExecuteScalar());
            cnx.Close();
            int id_usager = id1 + 1;

        cnx = new SqlConnection(str);
        //choisir le dernier Id_Personne
        cnx.Open();
            string sql3 = "SELECT TOP 1 Id_Personne FROM [dbo].[Personne] order by Id_Personne DESC";
            SqlCommand cmd3 = new SqlCommand(sql3, cnx);
            cmd3.CommandType = CommandType.Text;
            int id3 = Convert.ToInt32(cmd3.ExecuteScalar());
            cnx.Close();
            int id_personne = id3;

        cnx = new SqlConnection(str);
        //Insérer les infos dans [User]
        cnx.Open();
             string sql1 = @"INSERT INTO [User](Id_User,Id_Personne,Id_Acces,Id_Statut,email,mdp,tel) 
                                VALUES('" + id_usager + "','"+id_personne+"','" + u.email + "', '" + u.mdp + "')";
            SqlCommand cmd1 = new SqlCommand(sql1, cnx);
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            cnx.Close();
        
    }
    #endregion
    public bool Reserver(int idArticle)
    {
        bool success = false;
        using(SqlConnection cnx = new SqlConnection(str))
        {
            cnx.Open();

            string strSqlCmd_GetExemplaire = @"SELECT X.Id_Exemplaire
                                                FROM [dbo].[Exemplaire] as X
                                               WHERE X.Id_Article = @idArticle
                                                    AND X.Id_Exemplaire NOT IN (SELECT Id_Exemplaire 
                                                                                   FROM [dbo].[Reservation])";
            SqlCommand SqlCmd_GetExemplaire = new SqlCommand(strSqlCmd_GetExemplaire, cnx);
            SqlCmd_GetExemplaire.Parameters.AddWithValue( "@idArticle", idArticle.ToString());
            int idExemplaire = int.Parse(SqlCmd_GetExemplaire.ExecuteScalar().ToString());
            if (idExemplaire !=0)
            {
                string strSqlCmd_InsertInto = @"INSERT INTO [dbo].[Reservation] 
                                    ([Id_Usager], [Id_Exemplaire], [Date_Reservation])
                                    VALUES (@idUsager, @idExemplaire, GETDATE())";
                SqlCommand SqlCmd_InsertInto = new SqlCommand(strSqlCmd_InsertInto);
                SqlCmd_InsertInto.Parameters.AddWithValue("@idUsager", this.Id_usager);
                SqlCmd_InsertInto.Parameters.AddWithValue("@idExemplaire", idExemplaire);
                SqlCmd_InsertInto.ExecuteNonQuery();
                success = true;
            }
            else
            {
                success = false;
            }
            cnx.Close();
        }
        return success;
    }
    public string Reserver(int idUsager, int idArticle)
    {
        string info = "ERREUR : Essayer plus tard.";
        using (SqlConnection cnx = new SqlConnection(str))
        {
            cnx.Open();

            string strSqlCmd_GetExemplaire = @"SELECT (CASE 
			                                            WHEN X.Id_Exemplaire IN 
                                                                   (SELECT R.Id_Exemplaire FROM [dbo].[Reservation] as R, [dbo].[Exemplaire] as E 
                                                                        WHERE E.[Id_Article] = @idArticle AND R.[Id_Exemplaire] = E.[Id_Exemplaire] AND R.[Id_Usager] = @idUsager)
                                                                THEN 0
				                                        ELSE X.Id_Exemplaire END) as IdExemplaire
                                                FROM [dbo].[Exemplaire] as X
                                                WHERE X.Id_Article = @idArticle;";
            // AND X.Id_Exemplaire NOT IN (SELECT Id_Exemplaire FROM [dbo].[Reservation])";
            SqlCommand SqlCmd_GetExemplaire = new SqlCommand(strSqlCmd_GetExemplaire, cnx);
            SqlCmd_GetExemplaire.Parameters.AddWithValue("@idArticle", idArticle.ToString());
            SqlCmd_GetExemplaire.Parameters.AddWithValue("@idUsager", idUsager.ToString());
            int idExemplaire = int.Parse(SqlCmd_GetExemplaire.ExecuteScalar().ToString());
            if (idExemplaire != 0)
            {
                string strSqlCmd_InsertInto = @"INSERT INTO [dbo].[Reservation] 
                                    ([Id_Usager], [Id_Exemplaire], [Date_Reservation])
                                    VALUES (@idUsager, @idExemplaire, GETDATE())";
                SqlCommand SqlCmd_InsertInto = new SqlCommand(strSqlCmd_InsertInto, cnx);
                SqlCmd_InsertInto.Parameters.AddWithValue("@idUsager", idUsager.ToString());
                SqlCmd_InsertInto.Parameters.AddWithValue("@idExemplaire", idExemplaire.ToString());
                SqlCmd_InsertInto.ExecuteNonQuery();
                info = "Votre réservation a été enregistrée.";
            }
            else
            {
                info = "Cette article est déjà présent dans vos réservations.";
            }
            cnx.Close();
        }
        return info;
    }
    public bool ReserverArticle(int idUsager, int idArticle)
    {
        bool success = true;
        using(SqlConnection cnx = new SqlConnection(str))
        {
            cnx.Open();
            // ---------------------------------------------------------------------- //
            SqlCommand cmd = new SqlCommand("ReserverArticle", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            // ---------------------------------------------------------------------- //
            SqlParameter Id_Usager = new SqlParameter("idUsager", SqlDbType.Int);
            cmd.Parameters.Add("Id_Usager");
            // ---------------------------------------------------------------------- //
            SqlParameter Id_Article = new SqlParameter("idArticle", SqlDbType.Int);
            cmd.Parameters.Add("Id_Article");
            // ---------------------------------------------------------------------- //
            cmd.ExecuteNonQuery();
            // ---------------------------------------------------------------------- //
            cnx.Close();
        }
        return success;
    }
    #region EnvoyerMSG
    /* public string EnvoyerMSG()
     {

         try
         {
             MailMessage mail = new MailMessage("huifang.peng2013@gmail.com", mailUser, "Confirmation d'inscription", "Félicitations, vous êtes bien insrit(e)");
             mail.IsBodyHtml = true;
             SmtpClient client = new SmtpClient("smtp.gmail.com");
             client.Send(mail);
             return "Merci pour votre inscription.<br/> Vos identifiants de connexion viennent d'être envoyés à votre adresse mail";
         }
         catch (Exception)
         {
             return "Une erreur est survenue lors de l'envoi de vos identifiants.<br/>Nous régularisons la situation au meilleur délai.<br/>Merci de votre compréhension.";
         }
     }*/
    #endregion
    #region knownUser-vérifier login & mdp
    public int KnownUser(Usager u)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        string sql0 = "SELECT count(*) FROM [Usager] WHERE email=@email";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.AddWithValue("@email", u.email);
        int userExistant = 0;
        userExistant = Convert.ToInt32(cmd0.ExecuteScalar());
        cnx.Close();

        return userExistant;
    }



    public int KnownUser(string login, string mdp)
    {
        cnx = new SqlConnection(str);
        cnx.Open();

        string sql0 = "SELECT count(*) FROM [dbo].[Usager] WHERE identifiant=@login AND mdp=@mdp";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.AddWithValue("@login", login);
        cmd0.Parameters.AddWithValue("@mdp", mdp);
        int userExistant;
        userExistant = Convert.ToInt32(cmd0.ExecuteScalar());
        cnx.Close();
        return userExistant;
    }
    #endregion
    #region selectionProfil-Sélectionner Id_Usager selon email&mdp
    public DataTable selectionProfil(string email, string mdp)
    {
        cnx = new SqlConnection(str);
        DataTable dt = new DataTable();
        cnx.Open();
        string sql0 = "SELECT Id_Usager FROM [dbo].[Usager] WHERE identifiant=@email AND mdp=@mdp";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.AddWithValue("@email", email);
        cmd0.Parameters.AddWithValue("@mdp", mdp);
        SqlDataAdapter adaptater = new SqlDataAdapter(cmd0);
        adaptater.Fill(dt);
        cnx.Close();
        return dt;
 
    }
    #endregion
    #region SelectionInfoUsager
    public DataTable SelectionInfoUsager(int id)
    {
        cnx = new SqlConnection(str);
        DataTable dt = new DataTable();
        cnx.Open();
        string sql0 = "SELECT * FROM [dbo].[Usager] WHERE Id_Usager=@id";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.AddWithValue("@id", id);
        SqlDataAdapter adaptater = new SqlDataAdapter(cmd0);
        adaptater.Fill(dt);
        cnx.Close();
        return dt;
    }
    #endregion
    #region Modifier mot de passe par usager
    public void ModifierMDP(int id,string mdp)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        string sql0 = "UPDATE [dbo].[Usager] SET mdp=@mdp WHERE Id_Usager=@id";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        cmd0.Parameters.AddWithValue("@id", id);
        cmd0.Parameters.AddWithValue("@mdp", mdp);
        cmd0.ExecuteNonQuery();
        cnx.Close();
      
       
    }
    #endregion
    #region modifProfil-A modifier
    public void ModifProfil(Usager u,Adresse a)
    {
        cnx =new SqlConnection(str);
        cnx.Open();
        string sql0 = "SELECT Id_Personne FROM [dbo].[Usager] WHERE email='" + u.email+ "'";
        SqlCommand cmd0 = new SqlCommand(sql0, cnx);
        cmd0.CommandType = CommandType.Text;
        int id_personne = Convert.ToInt32(cmd0.ExecuteScalar());
        cnx.Close();

        cnx.Open();
        string sql3 = "UPDATE [dbo].[Adresse] SET adresse='"+a.adresse+"', adresse_complement='"+a.adresse_complement+"',code_postal='"+a.code_postal+"', ville='"+a.ville+"',pays='"+a.pays+"' WHERE Id_Personne="+id_personne;
        SqlCommand cmd3 = new SqlCommand(sql3, cnx);
        cmd3.CommandType = CommandType.Text;
        cmd3.ExecuteNonQuery();
        cnx.Close();    
    }
    #endregion
    #region RemplirGrid
    public void RemplirGrid(string req,GridView g)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        cmd_1 = new SqlCommand(req, cnx);
        cmd_1.CommandType = CommandType.Text;
        dr = cmd_1.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        g.DataSource = dt;
        g.DataBind();
        cnx.Close();
    }
    #endregion
    #region RemplirGridAvecFormat-page public
    public void RemplirGrid(int id_format,GridView g)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        cmd_1 = new SqlCommand("SELECT * From [Article],[Format_article],[Genre] WHERE (Id_Article In (SELECT Id_Article From [Exemplaire] WHERE Id_Emprunt=0)) AND([Article].Id_Format=[Format_article].Id_Format) AND ([Article].Id_Genre=[Genre].Id_Genre) AND ([Format_article].Id_Format=@id_format);", cnx);
        cmd_1.CommandType = CommandType.Text;
        cmd_1.Parameters.AddWithValue("@id_format", id_format);
        dr = cmd_1.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        g.DataSource = dt;
        g.DataBind();
        cnx.Close();
    }
    #endregion
    #region RemplirGridAvecGenre-page public
    public void RemplirGridGenre(int id_genre, GridView g)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        cmd_1 = new SqlCommand("SELECT * From [Article],[Format_article],[Genre] WHERE (Id_Article In (SELECT Id_Article From [Exemplaire] WHERE Id_Emprunt=0)) AND([Article].Id_Format=[Format_article].Id_Format) AND ([Article].Id_Genre=[Genre].Id_Genre) AND ([Genre].Id_Genre=@id_genre);", cnx);
        cmd_1.CommandType = CommandType.Text;
        cmd_1.Parameters.AddWithValue("@id_genre", id_genre);
        dr = cmd_1.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        g.DataSource = dt;
        g.DataBind();
        cnx.Close();
    }
    #endregion
    #region RemplirGridAvecGenreEtFormat-page public
    public void RemplirGridGenreFormat(int id_genre, int id_format,GridView g)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        cmd_1 = new SqlCommand("SELECT * From [Article],[Format_article],[Genre] WHERE (Id_Article In (SELECT Id_Article From [Exemplaire] WHERE Id_Emprunt=0)) AND([Article].Id_Format=[Format_article].Id_Format) AND ([Article].Id_Genre=[Genre].Id_Genre) AND ([Genre].Id_Genre=@id_genre) AND ([Format_article].Id_Format=@id_format);", cnx);
        cmd_1.CommandType = CommandType.Text;
        cmd_1.Parameters.AddWithValue("@id_genre", id_genre);
        cmd_1.Parameters.AddWithValue("@id_format", id_format);
        dr = cmd_1.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        g.DataSource = dt;
        g.DataBind();
        cnx.Close();
    }
    #endregion
    #region Executer
    public void Executer(string req)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
        cmd_1 = new SqlCommand(req, cnx);
        cmd_1.ExecuteNonQuery();
        cnx.Close();
    }
    #endregion
    #region RécupérerValeurs-DropDownList-Format
    public void RecupérerValeurs(string req,DropDownList ddl)
    {
        cnx = new SqlConnection(str);
        cnx.Open();
      
        cmd_1 = new SqlCommand(req, cnx);
        cmd_1.CommandType = CommandType.Text;
        /* Format fs;
         while (dr.Read())
         {           
             fs = new Format(dr["Id_Format"].ToString(), dr["Libelle_Format"].ToString());
             ddl.DataTextField = "Libelle_Format";
             ddl.DataValueField = "Id_Format";
             ddl.DataSource = dr;
             ddl.DataBind();
         }
         dr.Close();  */
        dt = new DataTable();
        SqlDataAdapter adaptater = new SqlDataAdapter(cmd_1);
        adaptater.Fill(dt);
        ddl.DataSource = dt.DefaultView;
        ddl.DataTextField = "Libelle_Format";
        ddl.DataValueField = "Id_Format";
        ddl.DataBind();
        cnx.Close();
        //return dt;
    }
    #endregion
    #region ConsulterEmprunt
  
    public void ConsulterEmprunt(int id,GridView g)
    {
      string req = @"SELECT * FROM[Article],[Format_article],[Genre],[Exemplaire],[Emprunt]
                WHERE[Emprunt].Id_Usager=@id AND([Article].Id_Format=[Format_article].Id_Format) AND([Article].Id_Genre=[Genre].Id_Genre) AND([Exemplaire].Id_Emprunt=[Emprunt].Id_Emprunt) AND([Exemplaire].Id_Article=[Article].Id_Article) AND[Exemplaire].Id_Exemplaire=[Emprunt].Id_Exemplaire;";
        cnx = new SqlConnection(str);
        cnx.Open();
        cmd_1 = new SqlCommand(req, cnx);
        cmd_1.CommandType = CommandType.Text;
        cmd_1.Parameters.AddWithValue("@id", id);
        dr = cmd_1.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        g.DataSource = dt;
        g.DataBind();
        cnx.Close();
    }
    #endregion
    #region Emprunter pour usagers
    public void Emprunter()
    {
        //admin
    }
    #endregion
    #region Rendre pour usager
    public void RendreArticle()
    {
        //admin
    }
    #endregion
}