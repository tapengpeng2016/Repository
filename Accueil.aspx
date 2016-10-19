<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accueil.aspx.cs" Inherits="Accueil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <div>
    <asp:Button ID="BTN_CONNEXION" CssClass="CONNEXION" runat="server" OnClick="BTN_CONNEXION_Click" Text="CONNEXION" />
    </div>
        <br />
    <br />
    <p></p>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
    <p>BIBLIOTHEQUE CINETHEQUE</p>
    <br />
    <br />
    <div>
    <asp:Table ID="Table1" runat="server" Height="65px" Width="218px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                   <asp:Label ID="LB_FORMAT"   runat="server" Text="Format: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                 <asp:DropDownList ID="DDL_FORMAT" Width="100px" OnSelectedIndexChanged="DDL_FORMAT_SelectedIndexChanged" AutoPostBack="True" runat="server">
            
                 </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                 <asp:Label ID="LB_GENRE" runat="server" Text="Genre: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DDL_GENRE" AutoPostBack="true" Width="100px" OnSelectedIndexChanged="DDL_GENRE_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="0">Tous sélectionner</asp:ListItem>
                    <asp:ListItem Value="1">Science</asp:ListItem>
                    <asp:ListItem Value="2">Mode</asp:ListItem>
                    <asp:ListItem Value="3">BD</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
    </div>
 <br />  
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="margin-top: 3px" Width="653px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Article">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nom") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nom") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Auteur">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Auteur") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Auteur") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Genre">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Libelle_Genre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Libelle_Genre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Format">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Libelle_Format") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Libelle_Format") %>'></asp:Label>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
   
</asp:Content>

