<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallBack1.aspx.cs" Inherits="CallBack1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function ClientCallBack(result, context) {
            var compte_destinataire = document.forms[0].elements['compte_destinataire'];
            compte_destinataire.innerHTML = "";

            var ligne = result.split('|');
            for (var i = 0; i < ligne.length; i++) {
                var option=document.createElement("option");
                option.value = ligne[i];
                option.innerHTML = ligne[i];
                //ajoute option dans la dropdownlist de destinaire
                compte_destinataire.appendChild(option);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Compte emetteur:
        <asp:DropDownList ID="compte_emetteur" runat="server">
            <asp:ListItem>Choisir</asp:ListItem>
            <asp:ListItem Value="P">Compte personnel</asp:ListItem>
            <asp:ListItem Value="L">Livret</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Compte destinaire:
        <asp:DropDownList ID="compte_destinataire" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Montant: 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="virer_Click" Text="virer" />
    
    </div>
    </form>
</body>
</html>
