<%@ Page Title="" Language="C#" MasterPageFile="~/PageNormale.master" AutoEventWireup="true" CodeFile="data_binding.aspx.cs" Inherits="data_binding" Trace="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div _designerregion="0" style="margin-left: 40px">
        <asp:Label ID="Label1" runat="server" Text="Quel est votre département?"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem Value="75">Paris</asp:ListItem>
            <asp:ListItem Value="76">Le Havre</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Code postal :"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="<%#DropDownList2.SelectedValue %>"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Heure de modification : "></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="<%# MiseALHeure() %>"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Index correspondant :"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" Width="633px">
         
            
    </asp:GridView>
        <br />
    <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="628px">
        <ItemTemplate>
            <%#Container.DataItem %>:
            <%#((ListItem)Container.DataItem).Value %>
        </ItemTemplate>
    </asp:DataList>
        <br />
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    </asp:Content>

