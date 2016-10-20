<%@ Page Language="C#" AutoEventWireup="true" CodeFile="session.aspx.cs" Inherits="Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 778px; margin-left: 276px">
    
        <br />
        <br />
        <br /><div>
            <p style="margin-left: 80px">
                CONNEXION</p>
        </div>
        <asp:Table ID="Table1" runat="server" Width="577px" style="margin-left: 0px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Label ID="Label1" runat="server" Text="Login: "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="TXTB_LOGIN" runat="server"></asp:TextBox></asp:TableCell>
               <asp:TableCell runat="server"><asp:RequiredFieldValidator runat="server" ControlToValidate="TXTB_LOGIN" ValidationGroup="CONNEXION" ErrorMessage="champs obligatoire"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="inscription" ControlToValidate="TXTB_LOGIN" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Mail erroné"></asp:RegularExpressionValidator>

               </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Label ID="Label2" runat="server" Text="Mote de passe: "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">    <asp:TextBox ID="TXTB_MDP" TextMode="Password" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell runat="server"><asp:RequiredFieldValidator runat="server" ControlToValidate="TXTB_MDP" ValidationGroup="CONNEXION" ErrorMessage="champs obligatoire"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
           

        </asp:Table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:Label ID="LB_MSG" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BTN_CONNECTER" runat="server" ValidationGroup="CONNEXION" OnClick="BTN_CONNECTER_Click" Text="Connecter" Width="89px" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
