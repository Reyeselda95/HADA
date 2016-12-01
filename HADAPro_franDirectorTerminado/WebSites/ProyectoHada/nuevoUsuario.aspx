<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="nuevoUsuario.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" Runat="Server">



  <div class="page-header" id="tit">
    <h1>Nuevo Usuario</h1>
  </div>

  <asp:Panel ID="PanelError" runat="server" Visible=false>
                <div class="alert hidden-phone alert-error">
                <div class="pull-left" id="ajuste">Todos los datos son obligatorios y el DNI debe ser numérico de tamaño 8!</div>
                </div>
  </asp:Panel>

  <div class="well">
    <form>
        <asp:Label ID="Label1" runat="server" Text="DNI (será tu forma de acceder al sitio)"></asp:Label><br />
        <asp:TextBox ID="nuevoDNI" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Nombre y Apellidos"></asp:Label><br />
        <asp:TextBox ID="nuevoNombre" runat="server"></asp:TextBox>
        <asp:TextBox ID="nuevoApellidos" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="Contraseña" TextMode="Password"></asp:Label><br />
        <asp:TextBox ID="nuevoPass" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Crear" CssClass="btn btn-success" 
            onclick="Button1_Click" />
    </form>
  </div>



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="bajoCuerpo" Runat="Server">



</asp:Content>

