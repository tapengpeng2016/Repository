<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accueil.aspx.cs" Inherits="Accueil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .input-group, .alert-warning {
            max-width : 40em;
            margin-left : 10%;
        }
        .BTNconnexion {
            margin-left : 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
        <h1>Médiathèque</h1>
        <p>Bienvenue à la Médiathèque de Montparnasse, proche de la Gare, vous trouverez tous ce dont vous avez besoin pour vous divertir.</p>
        <p>Pas encore abonné(e), rendez-vous à la Médiathèque du 33 rue du Maine 75015 Paris</p>
        <p>
            <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
            S'identifier
            </button>
        </p>
    </div>
<!-- Modal S'identifier -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Se connecter</h4>
      </div>
      <div class="modal-body">
        <div class="input-group input-group-lg">
            <span class="input-group-addon" id="sizing-addon1">@</span>
            <asp:TextBox ID="TXT_MAIL" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div class="input-group input-group-lg">
            <span class="input-group-addon" id="sizing-addon1"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
            <asp:TextBox ID="TXT_MOTDEPASSE" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div id="attention" runat="server" visible="false"  class="alert alert-warning">
            <strong>Attention!</strong> <asp:Label ID="LBL_ERREUR" runat="server" Text=""></asp:Label>
        </div>
        <div style="margin-left:20%">   
            <br />
            <asp:Button ID="BTN_SECONNECTER" runat="server" Text="S'identifier" OnClick="BTN_SECONNECTER_Click" CssClass="btn btn-lg btn-success" />
        </div>
      </div>
    </div>
  </div>
</div>
<div class="page-header">
  <h1> Liste d'articles proposée par la Médiathèque <small> Filtrer par Genre et Format</small></h1>
</div>
    <asp:GridView ID="GV_ACCEUILPUBLIC" runat="server"></asp:GridView>
</asp:Content>