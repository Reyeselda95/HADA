<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="usuarios.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" Runat="Server">

    <form id="usuarios" class="form-inline" >    
      <div class="page-header" id="tit">
        <h1>Lista de Usuarios</h1>
      </div>
      <div class="container">

      <asp:Panel ID="PanelCorrectoBorr" runat="server" Visible=false>
                <div class="alert hidden-phone alert-success">
                <div class="pull-left" id="ajuste">¿Has perdido un cliente? :(</div>
                </div>
      </asp:Panel>

      <asp:Panel ID="PanelCorrectoMod" runat="server" Visible=false>
                <div class="alert hidden-phone alert-success">
                <div class="pull-left" id="ajuste">Ya hemos tomado nota de los cambios! ;)</div>
                </div>
      </asp:Panel>

      <asp:Panel ID="PanelError" runat="server" Visible=false>
                <div class="alert hidden-phone alert-error">
                <div class="pull-left" id="ajuste">No te puedes borrar a ti mismo, ¿No has visto Inception?</div>
                </div>
      </asp:Panel>

      <asp:Panel ID="PanelErrorModSession" runat="server" Visible=false>
                <div class="alert hidden-phone alert-error">
                <div class="pull-left" id="ajuste">Para editar tus propios datos tienes que hacerlo en Perfil!</div>
                </div>
      </asp:Panel>

      <asp:Panel ID="PanelErrorMod" runat="server" Visible=false>
                <div class="alert hidden-phone alert-error">
                <div class="pull-left" id="ajuste">Rellena todos los datos que tampoco son tantos!</div>
                </div>
      </asp:Panel>

        <table class="table">
          <thead>
            <tr>
              <th>#</th>
              <th>DNI</th>
              <th>Nombre</th>
              <th>Apellidos</th>
              <th>Fecha Alta</th>
              <th>ROL</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
        <% 
            for (int i = 0; i < this.usuariosDB.Length; i++ )
            { 
                Response.Write("<tr>");

                Response.Write("<td>" + (i+1) + "</td>");
                Response.Write("<td>" + this.usuariosDB[i].getDni() + "</td>");
                Response.Write("<td>" + this.usuariosDB[i].getNombre() + "</td>");
                Response.Write("<td>" + this.usuariosDB[i].getApellidos() + "</td>");
                Response.Write("<td>" + this.usuariosDB[i].getFechaAlta() + "</td>");
                Response.Write("<td>" + this.usuariosDB[i].getRol() + "</td>");

                Response.Write("<td>");
                Response.Write("<div class=\"btn-group\">");
                Response.Write("<a href=\"usuarios.aspx?op=mod&id=" + this.usuariosDB[i].getDni() + "\" class=\"btn\">Modificar</a>");
                Response.Write("<a href=\"usuarios.aspx?op=bor&id=" + this.usuariosDB[i].getDni() + "\" class=\"btn\">Borrar</a>");
                Response.Write("</div>");
                Response.Write("</td>");
                Response.Write("</tr>");
            }   
        %>
          </tbody>
        </table>
      </div>
    </form>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bajoCuerpo" Runat="Server">

    <asp:Panel ID="modificarPanel" runat="server" Visible=false>
        <div class="well">
            
            <h3><asp:Label ID="Label1" runat="server" Text="Nuevos datos"></asp:Label></h3>
            <span>Nombre y Apellidos</span><br />
            <asp:TextBox id="nuevoNombreTextBox" runat="server" CssClass="input-medium" />
            <asp:TextBox id="nuevoApellidosTextBox" runat="server" CssClass="input-medium" /><br />
            <span>Nuevo rol</span><br />
            <asp:DropDownList ID="nuevoRolDropDownList" runat="server">
                    <asp:ListItem value="registrado">Registrado</asp:ListItem>
                    <asp:ListItem value="gerente">Gerente</asp:ListItem>
            </asp:DropDownList><br />

            <span>Nueva contraseña</span><br />
            <asp:TextBox id="nuevoPassTextBox" runat="server" CssClass="input-medium" TextMode="Password"/><br />

            <asp:Button id="aceptarCambios" Text="Aceptar" runat="server" 
                CssClass="btn btn-success" onclick="aceptarCambios_Click" />
            
        </div>
    </asp:Panel>

</asp:Content>