<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="articulos.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">

    <form id="busquedaArticulos" class="form-inline" action="" >

      <div class="page-header" id="tit">
        <h1>Artículos</h1>
        <div>
          <label>Buscar Articulos:</label>
          <div>
            
            <asp:TextBox id="busquedaArticuloTextBox" runat="server" CssClass="input-medium" />
            <asp:Button ID="busquedaButton" runat="server" OnClick="busquedaButton_Click" Text="Buscar" CssClass="btn"/>

          </div>
        </div>
      </div>
       <div class="row">
    <% Videoclub.UsuarioEN usuarioActual = (Videoclub.UsuarioEN)Session["Usuario"];

       if (usuarioActual.getRol().ToString() == "registrado")
       {
           for (int i = 0; i < articulos_on.Length; i++)
           { 
            %>
            <div class="span4">
              <div class="well">

                <h4><% Response.Write(articulos_on[i].Nombre); %></h4>
                <p><% Response.Write(articulos_on[i].Descripcion); %></p>
                <p>Cod: <% Response.Write(articulos_on[i].Id); %><br />Precio: <% Response.Write(articulos_on[i].Precio); %>€ <br />Stock: <% if (articulos_on[i].Stock > 0) Response.Write("Stock disponible"); else Response.Write("Stock agotado");%></p>
                <img alt="Imagen no disponible" src="<% Response.Write(articulos_on[i].Image); %>" />
                <br /><br />
                  <br />
              </div>
            </div>

            <% }
       }
       else if (usuarioActual.getRol().ToString() == "gerente")
       {
           for (int i = 0; i < articulos.Length; i++)
           { 
            %>
            <div class="span4">
              <div class="well">

                <h4><% Response.Write(articulos[i].Nombre); %></h4>
                <p><% Response.Write(articulos[i].Descripcion); %></p>
                <p>Cod: <% Response.Write(articulos[i].Id); %><br />Precio: <% Response.Write(articulos[i].Precio); %>€ <br />Stock: <% Response.Write(articulos[i].Stock);%><br />Activo: <% if (articulos[i].Activo == 1) Response.Write("ARTICULO EN CIRCULACIÓN"); else Response.Write("ARTICULO RETIRADO"); %></p>
                <img alt="Imagen no disponible" src="<% Response.Write(articulos[i].Image); %>" />
                <br /><br />
                  <%
               if (usuarioActual.getRol().ToString() == "gerente")
               {
                   Response.Write("<a id=\"Cuerpo_LinkButton1\" class=\"btn btn-warning\" href=\"articulos.aspx?id=" + articulos[i].Id + "&amp;mode=modificar\">Modificar</a>&nbsp;&nbsp;&nbsp;");

                   if (articulos[i].Activo == 1)
                   {
                       Response.Write("<a id=\"Cuerpo_LinkButton1\" class=\"btn btn-warning\" href=\"articulos.aspx?id=" + articulos[i].Id + "&amp;mode=borrar\">Deshabilitar</a>");
                   }
                   else if (articulos[i].Activo == 0)
                   {
                       Response.Write("<a id=\"Cuerpo_LinkButton1\" class=\"btn btn-warning\" href=\"articulos.aspx?id=" + articulos[i].Id + "&amp;mode=activar\">Habilitar</a>");
                   }
               }
                       %>
                  <br />
              </div>
            </div>

            <% } 
       }%>
       
        </div>
      
      <div class="container">
           <% 
                if (usuarioActual.getRol().ToString() == "gerente")
                {
                   if (Request.QueryString["mode"] == "modificar"){
                    %>
                     <h2>Modificar Artículo código <% Response.Write(id); %></h2>
                    <h5>Debes rellenar todos los campos para la modificación</h5>
              <%}else{%>
                     <h2>Nuevo Artículo</h2>
              <%}%>
              <table class="table">
                <tbody>
                  <tr>
                    <td>Nombre:</td>
                    <th>
                      <asp:TextBox id="nuevoArtNombre" runat="server" CssClass="input-medium" /> 
                    </th>
                  </tr>
                  <tr>
                    <td>Descripción:</td>
                    <td>
                      <asp:TextBox id="nuevoArtDescripcion" runat="server" CssClass="input-medium" /> 
                    </td>
                  </tr>
                  <tr>
                    <td>Stock:</td>
                    <td>
                      <asp:TextBox id="nuevoArtStock" runat="server" CssClass="input-medium" />
                    </td>
                  </tr>
                  <tr>
                    <td>Precio:</td>
                    <td>
                      <asp:TextBox id="nuevoArtPrecio" runat="server" CssClass="input-medium" /> 
                    </td>
                  </tr>
                  <tr>
                    <td>Foto:</td>
                    <td>
                      <asp:TextBox id="nuevoArtFoto" runat="server" CssClass="input-medium" /> 
                    </td>
                  </tr>
                </tbody>
              </table>
              <% 
                  if(Session["Usuario"] != "")
                  {
                    if (Request.QueryString["mode"] == "modificar"){
                    %>

                    <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="Insertar_Click"/>
          
              <%}else{%>

                    <asp:Button ID="Insertar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="Insertar_Click"/>
          
              <%    }
                }%>
            <br/> <br />
          </div>
          <p class="text-info lead">Puedes modificar los artículos o añadir nuevos</p>
        </form>
    <% } %>

</asp:Content>

