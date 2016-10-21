<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Espace_Usager.aspx.cs" Inherits="Espace_Usager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .table {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BTN_DECONNEXION" runat="server" OnClick="BTN_DECONNEXION_Click" Text="DECONNECTER" /> </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
        <asp:Button ID="BTN_EMPRUNT" OnClick="BTN_Emprunt_Click" runat="server" Text="Mes emprunts" />
        <asp:Button ID="BTN_RESERVATION" runat="server" Text="Mes Réservations" OnClick="BTN_RESERVATION_Click" />

        <asp:Panel ID="PL_ACCUEIL" runat="server">
            <asp:Panel ID="PL_RE" Visible="false" runat="server">
                <asp:Label ID="LB_IDARTICLE" Visible="false" runat="server" Text=""></asp:Label>
                <asp:Label ID="LB_NOMARTICLE" runat="server" Text=""></asp:Label>
                <asp:Label ID="LB_AUTEUR" runat="server" Text=""></asp:Label>
                <asp:Button ID="BTN_RESERVER" runat="server" Visible="false" Text="Réserver" OnClick="BTN_RESERVER_Click" />
                <br />
                <asp:Label ID="LB_DISPONIBLE" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:GridView ID="GV_ACCEUIL" runat="server" AutoGenerateColumns="False" OnRowCommand="GV_ACCUEIL_RowCommand" DataKeyNames="id" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GV_ACCEUIL_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="Titre de l'article" HeaderText="Titre de l'article" SortExpression="Titre de l'article" />
                    <asp:BoundField DataField="Format" HeaderText="Format" SortExpression="Format" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                    <asp:BoundField DataField="Acteurs/Auteurs" HeaderText="Acteurs/Auteurs" SortExpression="Acteurs/Auteurs" />
                    <asp:BoundField DataField="Exemplaires disponibles" HeaderText="Exemplaires disponibles" ReadOnly="True" SortExpression="Exemplaires disponibles" />
                    <asp:BoundField DataField="Disponibilité" HeaderText="Disponibilité" ReadOnly="True" SortExpression="Disponibilité" />
                    <asp:ButtonField ButtonType="Button" Text="Réserver" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:InscriptionConnectionString1 %>" SelectCommand="SELECT tab.idArticle as id, 
		tab.nomArticle as 'Titre de l''article', 
		F.Libelle_Format as 'Format', 
		G.Libelle_Genre as 'Genre',
		tab.auteurs as 'Acteurs/Auteurs',
		COUNT(CASE WHEN tab.Id_Emprunt = 0 THEN 1 ELSE NULL END) as 'Exemplaires disponibles',
		(CASE 
			WHEN COUNT(CASE WHEN tab.Id_Emprunt = 0 THEN 1 ELSE NULL END) = 0 
				THEN 'Réserver' 
				ELSE 'Emprunter' 
		END) AS 'Disponibilité'
FROM 
	(SELECT A.Id_Article AS idArticle, 
			A.Nom AS nomArticle, 
			A.Id_Format AS idFormat, 
			A.Id_Genre AS idGenre, 
			A.Auteur AS auteurs, 
			E.Id_Exemplaire AS idExemplaire, 
            E.Numero AS numero, 
			E.Id_Emprunt
		FROM  Article as A,
              Exemplaire as E
		WHERE A.Id_Article = E.Id_Article) AS tab,
      [Format_article] AS F,
      [Genre] AS G
WHERE  idGenre = G.Id_Genre
		AND idFormat = F.Id_Format
GROUP BY tab.nomArticle, 
		tab.idArticle, 
		F.Libelle_Format, 
		G.Libelle_Genre,
		tab.auteurs"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="PL_RESERVATION" Visible="false" runat="server">
            <h1>Mes réservations <asp:LinkButton ID="LB_FERMER_RESERVATION" runat="server" OnClick="LB_FERMER_RESERVATION_Click">Fermer</asp:LinkButton></h1>
            <asp:Panel ID="PL_SUPPRIMER" Visible="false" runat="server">
                <asp:Label ID="LB_IDRESERVATION" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="LB_SELECTIONRESERVATION" runat="server" Text="Label"></asp:Label>
                <br />
                <p>Confirmer l'annulation de votre réservation : <asp:Button ID="BTN_SUPPRIMERRESERVATION" runat="server" Text="Annuler ma réservation" OnClick="BTN_SUPPRIMERRESERVATION_Click" /></p>
            </asp:Panel>
            <asp:GridView ID="GV_RESERVATION" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Reservation,Id_Article,Id_Exemplaire1" DataSourceID="SqlDataSource3" OnRowCommand="GV_RESERVATION_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id_Reservation" HeaderText="Id_Reservation" InsertVisible="False" ReadOnly="True" SortExpression="Id_Reservation" Visible="False" />
                    <asp:BoundField DataField="Id_Usager" HeaderText="Id_Usager" SortExpression="Id_Usager" Visible="False" />
                    <asp:BoundField DataField="Id_Exemplaire" HeaderText="Id_Exemplaire" SortExpression="Id_Exemplaire" Visible="False" />
                    <asp:BoundField DataField="Date_Reservation" HeaderText="Date_Reservation" SortExpression="Date_Reservation" />
                    <asp:BoundField DataField="Id_Article" HeaderText="Id_Article" InsertVisible="False" ReadOnly="True" SortExpression="Id_Article" Visible="False" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                    <asp:BoundField DataField="Id_Format" HeaderText="Id_Format" SortExpression="Id_Format" Visible="False" />
                    <asp:BoundField DataField="Id_Genre" HeaderText="Id_Genre" SortExpression="Id_Genre" Visible="False" />
                    <asp:BoundField DataField="Auteur" HeaderText="Auteur" SortExpression="Auteur" />
                    <asp:BoundField DataField="Id_Exemplaire1" HeaderText="Id_Exemplaire1" InsertVisible="False" ReadOnly="True" SortExpression="Id_Exemplaire1" Visible="False" />
                    <asp:BoundField DataField="Numero" HeaderText="Numero" SortExpression="Numero" />
                    <asp:BoundField DataField="Id_Article1" HeaderText="Id_Article1" SortExpression="Id_Article1" Visible="False" />
                    <asp:BoundField DataField="Id_Emprunt" HeaderText="Id_Emprunt" SortExpression="Id_Emprunt" Visible="False" />
                    <asp:ButtonField ButtonType="Button" Text="Annuler la réservation" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:InscriptionConnectionString1 %>" SelectCommand="SELECT * FROM [dbo].[Reservation] as R, [dbo].[Article] as A, [dbo].[Exemplaire] as X
WHERE R.Id_Exemplaire = X.Id_Exemplaire AND X.Id_Article = A.Id_Article And R.Id_Usager = 3;"></asp:SqlDataSource>
        </asp:Panel>
       <asp:Panel ID="PL_EMPRUNT" runat="server" Width="102%" Height="358px">
            <asp:GridView ID="GV_EMPRUNT" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="777px" Height="220px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Numéro ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Numero") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Numero") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Article">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Nom") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Nom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Auteur">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Auteur") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Auteur") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Format">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Libelle_Format") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Libelle_Format") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Genre">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Libelle_Genre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Libelle_Genre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Emprunt">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"  Text='<%# Bind("DateEmprunt") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server"  Text='<%# Bind("DateEmprunt") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Retour Avant">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server"   Text='<%# Bind("DateRetourEstimee") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server"  Text='<%# Bind("DateRetourEstimee") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
     </asp:Panel>
     <asp:Panel ID="PL_PROFIL" runat="server">
             <asp:Table ID="T_PROFIL" runat="server" Width="905px" CssClass="table">
        
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LB_CIVILITE" Visible="false" runat="server" Text="Civilité: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>                        
               <asp:DropDownList ID="DDL_CIVILITE" Visible="false" CssClass="tbox" runat="server">
                        <asp:ListItem Text="monsieur" Value="Monsieur">Monsieur</asp:ListItem>
                        <asp:ListItem Text="madame" Value="Madame">Madame</asp:ListItem>
               </asp:DropDownList>
               </asp:TableCell>
               <asp:TableCell> </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell>Nom:</asp:TableCell>
               <asp:TableCell>
                    <asp:TextBox ID="TXTB_NOM" ReadOnly="true" CssClass="tbox txtbNom"  Text="" OnTextChanged="TXTB_NOM_TextChanged"  runat="server"></asp:TextBox>
               </asp:TableCell>
               <asp:TableCell> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="inscription" runat="server" ControlToValidate="TXTB_NOM" ErrorMessage="champ obligatoire"></asp:RequiredFieldValidator> 
               </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
                <asp:TableCell>Prénom: </asp:TableCell>
                <asp:TableCell> 
                    <asp:TextBox ID="TXTB_PRENOM" ReadOnly="true" CssClass="tbox txtbPrenom"  runat="server"></asp:TextBox>               
                </asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="inscription" runat="server" ControlToValidate="TXTB_PRENOM" ErrorMessage="champ obligatoire"></asp:RequiredFieldValidator> 
                </asp:TableCell>     
         </asp:TableRow>        
        <asp:TableRow>
              <asp:TableCell>E-mail:</asp:TableCell>
              <asp:TableCell>
                    <asp:TextBox ID="TXTB_MAIL" CssClass="tbox" ReadOnly="true" runat="server"></asp:TextBox>              
              </asp:TableCell>
              <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="inscription" ControlToValidate="TXTB_MAIL" ErrorMessage="champ obligatoire"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="inscription" ControlToValidate="TXTB_MAIL" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Mail erroné"></asp:RegularExpressionValidator>                
            </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
              <asp:TableCell>Mot de passe:</asp:TableCell>
              <asp:TableCell>
                    <asp:TextBox ID="TXTB_MDP" TextMode="Password" ReadOnly="true" CssClass="tbox" runat="server"></asp:TextBox>             
                    <asp:Button ID="BTN_MODIF_MDP" runat="server" OnClick="BTN_MODIF_MDP_Click" Text="Modifer mot de passe" />
              </asp:TableCell>
              <asp:TableCell>
                  
            </asp:TableCell>
       </asp:TableRow>
        <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                                  
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
            <asp:Label ID="LB_PROFIL" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <asp:Panel ID="PL_MDP" visible="false" runat="server">
       <asp:Table ID="T_MDP" runat="server" Width="722px" Height="149px">                
        <asp:TableRow>
                <asp:TableCell>
                    
                </asp:TableCell>              
                <asp:TableCell> 
                    <asp:Label ID="Label8"  runat="server" Text="MODIFICATION DE MOT DE PASSE"></asp:Label>                
                </asp:TableCell>
                <asp:TableCell>                          
                </asp:TableCell>
       </asp:TableRow>
        <asp:TableRow>
              <asp:TableCell>Ancien mot de passe:</asp:TableCell>
              <asp:TableCell>
                    <asp:TextBox ID="TXTB_ANCIENMDP" TextMode="Password" runat="server"></asp:TextBox>              
              </asp:TableCell>
              <asp:TableCell>
                  <asp:RequiredFieldValidator ID="RFV_OLDMDP" ControlToValidate="TXTB_ANCIENMDP" runat="server" ForeColor="Red" ErrorMessage="Veuillez entrer votre ancien mot de passe"></asp:RequiredFieldValidator>               
            </asp:TableCell>
       </asp:TableRow>
       
       <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="LB_NEWMDP1"  runat="server" Text="Nouveau mot de passe:"></asp:Label></asp:TableCell>
            <asp:TableCell>
                    <asp:TextBox ID="TXTB_NEWMDP1"  TextMode="Password" CssClass="tbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RFV_NEWMDP1" ControlToValidate="TXTB_NEWMDP1" runat="server" ForeColor="Red" ErrorMessage="Veuillez entrer votre nouveau mot de passe"></asp:RequiredFieldValidator><br /> 
                <asp:CompareValidator ID="CV_NEWMDP1" runat="server" ControlToValidate="TXTB_NEWMDP1" ControlToCompare="TXTB_NEWMDP2" ForeColor="Red" ErrorMessage="Deux saisies non identiques"></asp:CompareValidator>                       
            </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="LB_NEWMDP2" runat="server" Text="Nouveau mot de passe:"></asp:Label></asp:TableCell>
            <asp:TableCell>
                    <asp:TextBox ID="TXTB_NEWMDP2" TextMode="Password" CssClass="tbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RFV_NEWMDP2" ControlToValidate="TXTB_NEWMDP2" runat="server" ForeColor="Red" ErrorMessage="Veuillez entrer votre nouveau mot de passe"></asp:RequiredFieldValidator><br />
                <asp:CompareValidator ID="CV_NEWMDP2" runat="server" ControlToValidate="TXTB_NEWMDP2" ControlToCompare="TXTB_NEWMDP1" ForeColor="Red" ErrorMessage="Deux saisies non identiques"></asp:CompareValidator>                         
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>                                     
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:Button ID="BTN_VALIDERMDP" runat="server" OnClick="BTN_VALIDERMDP_Click" Text="VALIDER" />
                                           
            </asp:TableCell>
        </asp:TableRow>
            </asp:Table>
                <asp:Label ID="LB_MSG" runat="server" Text=""></asp:Label> 
        </asp:Panel>   
    </div>
    </form>
</body>
</html>
