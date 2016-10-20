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

        <div>
            <asp:Label ID="LB_IDUSAGER" runat="server" Text="Id usager:"></asp:Label>
            <asp:DropDownList ID="DDL_ID" runat="server">

            </asp:DropDownList>
        </div>
    <div>
        <asp:Panel ID="PL_EMPRUNT" runat="server">
            <asp:Table ID="T_EMPRUNT" runat="server">

            </asp:Table>
            <asp:GridView ID="GV_EMPRUNT" runat="server" AutoGenerateColumns="False">

                <Columns>
                    <asp:TemplateField HeaderText="Numero">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Numero") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Numero") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Article">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nom") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField />
                    <asp:BoundField />
                    <asp:BoundField />
                    <asp:TemplateField HeaderText="Disponibilité">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Disponibilité") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Disponibilité") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
