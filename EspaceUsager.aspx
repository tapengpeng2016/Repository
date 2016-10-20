<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EspaceUsager.aspx.cs" Inherits="EspaceUsager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Médiathèque</a>
    </div>
    <ul class="nav navbar-nav">
      <li><asp:LinkButton ID="LBTN_ACCUEIL" runat="server" OnClick="LBTN_ACCUEIL_Click">Accueil</asp:LinkButton></li>
      <li><asp:LinkButton ID="LBTN_EMPRUNT" runat="server" OnClick="LBTN_EMPRUNT_Click">Mes Emprunts</asp:LinkButton></li>
      <li><asp:LinkButton ID="LBTN_RESERVATION" runat="server" OnClick="LBTN_RESERVATION_Click">Mes Réservations</asp:LinkButton></li>
    </ul>
    <ul class="nav navbar-nav navbar-right">
      <li>
          <asp:LinkButton ID="LBTN_ABONNEMENT" runat="server" OnClick="LBTN_ABONNEMENT_Click">
              <span class="glyphicon glyphicon-user"></span><asp:Label ID="LB_USAGER" runat="server" Text=""></asp:Label>
          </asp:LinkButton>
      </li>
      <li><asp:LinkButton ID="LBTN_DECONNEXION" runat="server" OnClick="LBTN_DECONNEXION_Click"><span class="glyphicon glyphicon-log-out"></span>Se déconnecter</asp:LinkButton></li>
    </ul>
  </div>
</nav>
    <asp:Panel ID="PL_ACCUEIL" runat="server" Visible="true">
        <!-- Modal S'identifier -->
<div class="modal fade" id="myModalAccueil" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Se connecter</h4>
      </div>
      <div class="modal-body">
          <h3>Article :  <span class="label label-default"><asp:Label ID="LB_NOMARTICLE" runat="server" Text=""></asp:Label></span></h3>
          <br />
        <div id="attention" runat="server" visible="false"  class="alert alert-warning">
            <strong>Attention!</strong> <asp:Label ID="LBL_ERREUR" runat="server" Text=""></asp:Label>
        </div>
        <div style="margin-left:20%">   
            <br />
            <asp:Button ID="BTN_ACCUEIL" runat="server" Text="S'identifier" CssClass="btn btn-lg btn-success" />
        </div>
      </div>
    </div>
  </div>
</div>
        <div class="page-header">
            <h1> Articles <small> Emprunter les articles disponibles ou réserver les</small></h1>
        </div>
        <br />
        Genre :
        <asp:DropDownList ID="DDL_GENRE" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource2" DataTextField="libelle" DataValueField="libelle" OnSelectedIndexChanged="DDL_GENRE_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="%">TOUT</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MEDIATHEQUEConnectionString %>" SelectCommand="SELECT DISTINCT libelle FROM [Genre]"></asp:SqlDataSource>
        Format :
        <asp:DropDownList ID="DDL_FORMAT" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource3" DataTextField="libelle" DataValueField="libelle"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MEDIATHEQUEConnectionString %>" SelectCommand="SELECT DISTINCT libelle FROM [Format]"></asp:SqlDataSource>
        <asp:GridView ID="GV_ACCUEIL" GridLines="None" CssClass="table table-hover table-striped" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GV_ACCUEIL_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="Titre de l'article" HeaderText="Titre de l'article" SortExpression="Titre de l'article" />
                <asp:BoundField DataField="Format" HeaderText="Format" SortExpression="Format" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                <asp:BoundField DataField="Acteurs/Auteurs" HeaderText="Acteurs/Auteurs" SortExpression="Acteurs/Auteurs" />
                <asp:BoundField DataField="Exemplaires disponibles" HeaderText="Exemplaires disponibles" ReadOnly="True" SortExpression="Exemplaires disponibles" />
                <asp:BoundField DataField="Disponibilité" ReadOnly="True" SortExpression="Disponibilité" HeaderText="Disponibilité" />
                <asp:ButtonField ButtonType="Button" Text="Réserver/Emprunter" CommandName="RE" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MEDIATHEQUEConnectionString %>" SelectCommand="SELECT tab.idArticle AS id, tab.nomArticle AS 'Titre de l''article', F.libelle AS 'Format', G.libelle AS 'Genre', tab.acteurs AS 'Acteurs/Auteurs', COUNT(CASE WHEN tab.idEmprunt IS NULL THEN 1 ELSE NULL END) AS 'Exemplaires disponibles', (CASE WHEN COUNT(CASE WHEN tab.idEmprunt IS NULL THEN 1 ELSE NULL END) = 0 THEN 'Réserver' ELSE 'Emprunter' END) AS 'Disponibilité' FROM (SELECT A.idArticle, A.nom AS nomArticle, A.idFormat AS id_Format, A.idGenre AS id_Genre, A.acteurs, E.idExemplaire, E.numero, E.idEmprunt FROM Article AS A INNER JOIN Exemplaire AS E ON A.idArticle = E.idArticle) AS tab INNER JOIN Genre AS G ON tab.id_Genre = G.idGenre INNER JOIN Format AS F ON tab.id_Format = F.idFormat GROUP BY tab.nomArticle, tab.idArticle, F.libelle, G.libelle, tab.acteurs"
            FilterExpression="Genre ='{0}' AND Format = '{1}'">
                <FilterParameters>
                    <asp:ControlParameter Name="Genre" ControlID="DDL_GENRE" PropertyName="SelectedValue" />
                    <asp:ControlParameter Name="Format" ControlID="DDL_FORMAT" PropertyName="SelectedValue" />
                </FilterParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:panel ID="PL_ABONNEMENT" runat="server" Visible="false">
        <div class="page-header">
            <h1> Mon Abonnement <small> Consulter mon abbonnement</small></h1>
        </div>
    </asp:panel>
    <asp:panel ID="PL_EMPRUNT" runat="server" Visible="false">
        <div class="page-header">
            <h1> Mes Emprunts <small> mes emprunts en cours et passés</small></h1>
        </div>
        <asp:GridView ID="GV_EMPRUNT" runat="server"></asp:GridView>
    </asp:panel>
    <asp:panel ID="PL_RESERVATION" runat="server" Visible="false">
        <div class="page-header">
            <h1> Mes Réservations <small> mes réservations en cours et passées</small></h1>
        </div>
        <asp:GridView ID="GV_RESERVATION" runat="server"></asp:GridView>
    </asp:panel>
</asp:Content>