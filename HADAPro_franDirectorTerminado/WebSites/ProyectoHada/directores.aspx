<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="directores.aspx.cs" Inherits="directores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">

    <form id="busquedaDirectores" class="form-inline" action="" >

      <div class="page-header" id="tit">
        <h1>Directores</h1>
        <div>
          <label>Buscar Directores:</label>
          <div>
            
            <asp:TextBox id="busquedaDirectorTextBox" runat="server" CssClass="input-medium" />
            <asp:Button ID="busquedaButton" runat="server" OnClick="busquedaButton_Click" Text="Buscar" CssClass="btn"/>

          </div>
        </div>
      </div>
       <div class="row">
    <% Videoclub.UsuarioEN usuarioActual = (Videoclub.UsuarioEN)Session["Usuario"];

       if (usuarioActual.getRol().ToString() == "registrado")
       {
           for (int i = 0; i < directorPorNombre.Length; i++)
           { 
            %>
            <div class="span4">
              <div class="well">

                <h4><% Response.Write(directorPorNombre[i].getNombre()); %></h4>
                <p><% Response.Write(directorPorNombre[i].getFechaNacimiento()); %></p>
                <p><% Response.Write(directorPorNombre[i].getLugarNacimiento()); %><br /><% Response.Write(directorPorNombre[i].getDescripcion()); %></p>
                <br /><br />
                  <br />
              </div>
            </div>

            <% }
       }
       else if (usuarioActual.getRol().ToString() == "gerente")
       {
           for (int i = 0; i < todosdirectores.Length; i++)
           { 
            %>
            <div class="span4">
              <div class="well">

                <h4><% Response.Write(todosdirectores[i].getNombre()); %></h4>
                <p> <% Response.Write(todosdirectores[i].getId()); %></p>
                <p><% Response.Write(todosdirectores[i].getFechaNacimiento()); %></p>
                <p><% Response.Write(todosdirectores[i].getLugarNacimiento()); %><br /><% Response.Write(todosdirectores[i].getDescripcion()); %></p>
         
                <br /><br />
                  <%
               if (usuarioActual.getRol().ToString() == "gerente")
               {
                   Response.Write("<a id=\"Cuerpo_LinkButton1\" class=\"btn btn-warning\" href=\"directores.aspx?id=" + todosdirectores[i].getId() + "&amp;nombre=" + todosdirectores[i].getNombre() + "&amp;fecha=" + todosdirectores[i].getFechaNacimiento() + "&amp;lugar=" + todosdirectores[i].getLugarNacimiento() + "&amp;desc=" + todosdirectores[i].getDescripcion() + "&amp;mode=modificar\">Modificar</a>&nbsp;&nbsp;&nbsp;");
                   Response.Write("<a id=\"Cuerpo_LinkButton1\" class=\"btn btn-warning\" href=\"directores.aspx?id=" + todosdirectores[i].getId() + "&amp;mode=borrar\">borrar</a>&nbsp;&nbsp;&nbsp;");
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
                     <h2>Modificar Director código <% Response.Write(id); %></h2>
                    <h5>Debes rellenar todos los campos para la modificación</h5>
              <%}else{%>
                     <h2>Nuevo Director</h2>
              <%}%>
              <table class="table">
                <tbody>
                  <tr>
                    <td>Nombre:</td>
                    <th>
                      <asp:TextBox id="nuevoDirNombre" runat="server" CssClass="input-medium" /> 
                    </th>
                  </tr>
                  <tr>
                    <td>Lugar de Nacimiento</td>
                    <td>
                      <asp:TextBox id="nuevoDirLugar" runat="server" CssClass="input-medium" /> 
                    </td>
                  </tr>
                  <tr>
                    <td>Fecha de Nacimiento</td>
                    <td>
                      <asp:TextBox id="nuevoDirFecha" runat="server" CssClass="input-medium" />
                    </td>
                  </tr>
                  <tr>
                    <td>Descripcion:</td>
                    <td>
                      <asp:TextBox id="nuevoDirDesc" runat="server" CssClass="input-medium" /> 
                    </td>
                  </tr>
                </tbody>
              </table>
              <% 
                  if(Session["Usuario"] != null)
                  {
                    if (Request.QueryString["mode"] == "modificar"){
                    %>

                    <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="Modificar_Click"/>
          
              <%}else{%>

                    <asp:Button ID="Insertar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="Insertar_Click"/>
          
              <%    }
                }%>
            <br/> <br />
          </div>
          <p class="text-info lead">Puedes modificar los directores o añadir nuevos</p>
        </form>
    <% } %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bajoCuerpo" Runat="Server">
</asp:Content>

