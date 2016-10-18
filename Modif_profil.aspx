<%@ Page Title="" Language="C#" MasterPageFile="~/PageNormale.master" AutoEventWireup="true" CodeFile="Modif_profil.aspx.cs" Inherits="Modif_profil" %>


  
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <script>
        
    </script>
    <style runat="server">
    .tbox{
        width:220px;
       height:20px;
       font-size:15px;
    }
    .txtbPrenom{
        text-transform : capitalize;
    }
    .txtbNom{
        text-transform : uppercase;
    }
    .FileUpload1{
         width:220px;
        height:20px;
    }
    .UploadButton{
        width:220px;
       height:20px;
       font-size:15px;
    }
    .IMGBT{
          width:220px;
       height:20px;
    }
        .table {
            margin-left: 0px;
        }
    </style>
    <asp:Label runat="server"> <div>MODIFICATION DU PROFIL</div></asp:Label>

        <hr />
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       <asp:Table ID="Table1" runat="server" Width="827px" CssClass="table">
              <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_MDP1" Visible="false" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell>         
                    
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Civilité: </asp:TableCell>
                <asp:TableCell>                        
               <asp:DropDownList ID="DDL_CIVILITE" CssClass="tbox" runat="server">
                        <asp:ListItem Text="monsieur" Value="Monsieur">Monsieur</asp:ListItem>
                        
<asp:ListItem Text="madame" Value="Madame">Madame</asp:ListItem>
                    
</asp:DropDownList>

</asp:TableCell>

                <asp:TableCell> </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Nom:*</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_NOM" CssClass="tbox txtbNom" Enabled="true" Text="" OnTextChanged="TXTB_NOM_TextChanged"  runat="server"></asp:TextBox>
                   
                
</asp:TableCell>
                <asp:TableCell> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="inscription" runat="server" ControlToValidate="TXTB_NOM" ErrorMessage="champ obligatoire"></asp:RequiredFieldValidator> 
</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Prénom:* </asp:TableCell>
                <asp:TableCell> 
                    <asp:TextBox ID="TXTB_PRENOM" CssClass="tbox txtbPrenom" Enabled="true" runat="server"></asp:TextBox>
                    
                
</asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="inscription" runat="server" ControlToValidate="TXTB_PRENOM" ErrorMessage="champ obligatoire"></asp:RequiredFieldValidator> 
</asp:TableCell>
           
             </asp:TableRow>
                     <asp:TableRow>
                <asp:TableCell>Avatar:</asp:TableCell>
                <asp:TableCell>
                              
                    <asp:FileUpload ID="FileUpload1" OnLoad="FileUpload1_Load" runat="server" />
                    <asp:Button ID="UploadButton" runat="server" OnClick="BTN_UPLOAD_Click" Text="UPLOAD" />
                   
</asp:TableCell>
                <asp:TableCell>
                            <asp:ImageButton ID="IMGBT" runat="server"></asp:ImageButton>
        
                    
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell>Téléphone:</asp:TableCell>
                 <asp:TableCell>
                     <asp:TextBox ID="TXTB_TEL" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                 <asp:TableCell>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXTB_TEL" ValidationExpression="\d{10}" ErrorMessage="TEL: XXXXXXXXXX"></asp:RegularExpressionValidator>
                
</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Adresse: </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_ADRESSE" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell> </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Adresse complément:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_ACOMPLEMENT" CssClass="tbox" runat="server"></asp:TextBox>

                
</asp:TableCell>
                <asp:TableCell> </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Code postal:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_CP" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTB_CP" ValidationExpression="\d{5}" ErrorMessage="code postal invalide"></asp:RegularExpressionValidator>
                
</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Ville:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_VILLE" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell> </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Pays:</asp:TableCell>
                <asp:TableCell>
                   <asp:DropDownList ID="DDL_PAYS" AutoPostBack="true" CssClass="tbox" runat="server">
</asp:DropDownList> 
                
</asp:TableCell>
                <asp:TableCell> </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>E-mail:*</asp:TableCell>
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
                <asp:TableCell>
                    <asp:Label ID="LB_MDP" Visible="false" runat="server" Text="Mot de passe actuel:"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_MDP" Visible="false" TextMode="Password" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell>         
                    
</asp:TableCell>
            </asp:TableRow>
                      <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LB_NEWMDP1" Visible="false" runat="server" Text="Nouveau mot de passe:"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_NEWMDP1" Visible="false" TextMode="Password" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell>         
                    
</asp:TableCell>
            </asp:TableRow>
                                 <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LB_NEWMDP2" Visible="false" runat="server" Text="Nouveau mot de passe:"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TXTB_NEWMDP2" Visible="false" TextMode="Password" CssClass="tbox" runat="server"></asp:TextBox>
                
</asp:TableCell>
                <asp:TableCell>         
                    
</asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="BT_VALIDER" runat="server" OnClick="BT_VALIDER_Click" ValidationGroup="inscription" Text="VALIDER"/>
                
</asp:TableCell>
                <asp:TableCell>
                    </asp:TableCell>
            </asp:TableRow>
 
        </asp:Table>
        <br />
        <asp:HyperLink href="profil.aspx" ID="HyperLink1" runat="server">Cliquez ici pour retourner au profil</asp:HyperLink>
		</div>
</asp:Content>

