<%@ Page Title="" Language="C#" MasterPageFile="~/PageNormale.master" AutoEventWireup="true" CodeFile="GestionEvenements.aspx.cs" Inherits="GestionEvenements" %>
<script runat="server">
    //4eme event
    void traiter_click(object sender, EventArgs e)
    {
        Label1.Text += "Vous avez cliqué!";
    }

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox><br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="traiter_click" /><br />
    <asp:ListBox ID="ListBox2" runat="server" OnLoad="ListBox1_Load"></asp:ListBox>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    

</asp:Content>

