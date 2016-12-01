<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="facturar.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">

    <form id="facturar" class="form-inline">
      <div class="page-header" id="tit">
        <h1>Reservas activas</h1>
      </div>
      <div class="container">
        <h5>Reserva num: 2312 Usuario: Federico</h5>
        <table class="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Cod</th>
              <th>Titulo</th>
              <th>
                <br> 
              </th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>1</td>
              <td>6655645</td>
              <td>Full Metal Jacket</td>
              <td>
                <asp:Button ID="Button2" runat="server" Text="Quitar" CssClass="btn btn-danger" />  
              </td>
            </tr>
            <tr>
              <td>2</td>
              <td>8887656</td>
              <td>Gran Torino</td>
              <td>
                <asp:Button ID="Button1" runat="server" Text="Quitar" CssClass="btn btn-danger" /> 
              </td>
            </tr>
            <tr>
              <td>*</td>
              <td><asp:TextBox id="busquedaPeliculaTextBox" runat="server" CssClass="input-medium" Text="Código película" /></td>
              <td></td>
              <td>
                <asp:Button ID="Insertar" runat="server" Text="Insertar" CssClass="btn btn-success" /> 
              </td>
            </tr>
          </tbody>
        </table>
        <table class="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Cod</th>
              <th>Nombre</th>
              <th>Precio</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>1</td>
              <td>53244622</td>
              <td>Figura X-Men</td>
              <td>69,90</td>
              <td>
              <asp:Button ID="Button3" runat="server" Text="Quitar" CssClass="btn btn-danger" /> 
              </td>
            </tr>
            <tr>
              <td>*</td>
              <td><asp:TextBox id="TextBox1" runat="server" CssClass="input-medium" Text="Código artículo" /></td>
              <td></td>
              <td></td>
              <td>
              <asp:Button ID="Button4" runat="server" Text="Insertar" CssClass="btn btn-success" /> 
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </form>







</asp:Content>

