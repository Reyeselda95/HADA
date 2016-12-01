<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="inicio.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" Runat="Server">

<asp:Panel ID="PanelCorrecto" runat="server" Visible=false>
                <div class="alert hidden-phone alert-success">
                <div class="pull-left" id="ajuste">Genial! Inicia sesión para empezar.</div>
                </div>
              </asp:Panel>


      <div class="page-header" id="tit">
        <h1>Bienvenido</h1>
      </div>
      <p class="text-info lead">Comience utilizando las opciones del menú superior</p>

</asp:Content>

