<%@ Page Title="" Language="C#" MasterPageFile="~/PageNormale.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div>
        PROFIL<br />
        <br />
&nbsp;<asp:Label ID="LB_MSG" runat="server" Text=""></asp:Label>
        <br />
        <br />
       
        
&nbsp;<asp:Table ID="Table1" runat="server">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server"><asp:ImageButton ID="IMAGEBT1" runat="server" /></asp:TableCell>
                 
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Label ID="Label1" runat="server" Text="Nom:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server"><asp:Label ID="LB_NOM" runat="server"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">  <asp:Label ID="Label2" runat="server" Text="Prénom: "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server"><asp:Label ID="LB_PRENOM" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Adresse:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_ADRESSE" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label4" runat="server" Text="Adresse complément:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_ACOMPLEMENT" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label5" runat="server" Text="Code postal:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_CP" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label6" runat="server" Text="Ville:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_VILLE" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label7" runat="server" Text="Pays"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_PAYS" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label8" runat="server" Text="Téléphone:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_TEL" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label9" runat="server" Text="E-mail:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="LB_MAIL" runat="server" Text=""></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
    <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Button ID="BTN_MODIF" runat="server" Text="MODIFIER" OnClick="BTN_MODIF_Click" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
  </asp:Content>
