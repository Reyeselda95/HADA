<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="reserva.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" Runat="Server">

     <form id="listaReservas" class="form-inline" >

       <div class="page-header" id="tit">
        <h1>Reserva actual</h1>
      </div>
      <div class="container">
        <table class="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Película</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>1</td>
              <td>Scarface</td>
              <td>
                <asp:Button ID="Button6" runat="server" Text="Quitar" CssClass="btn btn-danger" />  
              </td>
            </tr>
            <tr>
              <td>2</td>
              <td>Full Metal Jacket</td>
              <td>
                <asp:Button ID="Button1" runat="server" Text="Quitar" CssClass="btn btn-danger" />  
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    
      <p class="text-info lead">Corre al videoclub a recoger las películas!</p>
    </form>

</asp:Content>

