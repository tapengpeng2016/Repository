<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Espace_Gestionnaire.aspx.cs" Inherits="Espace_Gestionnaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     
        <asp:Label ID="LB_MSG" runat="server" Text=""></asp:Label>
        <asp:Button ID="BTN_EMPRUNT" runat="server" Text="Emprunter" />
        <asp:Label ID="Label1" runat="server" Text="Recherche par ID:"></asp:Label>
        <asp:TextBox ID="TXTB_RECHERCHEID" OnTextChanged="TXTB_RECHERCHEID_TextChanged" runat="server"></asp:TextBox>
        <div>
            <asp:Label ID="LB_IDUSAGER" runat="server" Text="Id usager:"></asp:Label>
            <asp:DropDownList ID="DDL_ID" runat="server">

            </asp:DropDownList>
        </div>
    <div>
        <asp:Panel ID="PL_EMPRUNT" runat="server">
            <asp:GridView ID="GV_USAGERS" Visible="false" runat="server"></asp:GridView>
            <asp:GridView ID="GV_EMPRUNT" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
