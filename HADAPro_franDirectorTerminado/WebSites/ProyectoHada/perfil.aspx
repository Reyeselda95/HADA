<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="perfil.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">

    <form id="actualizarPerfil" class="form-inline" >

      <div class="page-header" id="tit">
        <h1>Editar tu perfil</h1>
      </div>
      <div class="row">
        <div class="span4">
          <div class="well">
            <h5>DNI: <% Response.Write(usuarioActual.getDni().ToString() + usuarioActual.getLetraDni().ToString()); %></h5>
            <p>
              <b>Nombre: </b> <% Response.Write(usuarioActual.getNombre() + " " + usuarioActual.getApellidos()); %></p>
            <p>
              <b>Fecha Alta: </b> <% Response.Write(usuarioActual.getFechaAlta()); %> </p>
            <p>
              <b>Rol: </b> <% Response.Write(usuarioActual.getRol()); %> </p>
          </div>
        </div>
        <div class="span8">
          <div class="well">
            

              <asp:Panel ID="PanelError" runat="server" Visible=false>
                <div class="alert hidden-phone alert-error">
                <div class="pull-left" id="ajuste">Vaya, ¿No tienes nombre y/o apellidos?</div>
                </div>
              </asp:Panel>

              <asp:Panel ID="PanelCorrecto" runat="server" Visible=false>
                <div class="alert hidden-phone alert-success">
                <div class="pull-left" id="ajuste">Vale, a partir de ahora usaremos tu nuevo nombre!</div>
                </div>
              </asp:Panel>

            <asp:Label ID="Label1" runat="server" Text="Cambiar Nombre y Apellidos" /><br /> <br />
            
            <asp:TextBox id="nuevoNombreTextBox" runat="server" CssClass="input-medium" />
            <asp:TextBox id="nuevoApelidoTextBox" runat="server" CssClass="input-medium" /><br />
            <asp:DropDownList ID="nuevoRolDropDownList" runat="server">
                    <asp:ListItem value="registrado">Registrado</asp:ListItem>
                    <asp:ListItem value="gerente">Gerente</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button id="aceptarCamios" Text="Aceptar" runat="server" CssClass="btn btn-success" onclick="aceptarCambios_Click" />

          </div>
        </div>
      </div>
      <p class="text-info lead">Comprueba tus reservas en la zona de reserva del menú superior!</p>

    </form>

</asp:Content>

