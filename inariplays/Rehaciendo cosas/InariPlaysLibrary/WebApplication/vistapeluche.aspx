<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vistapeluche.aspx.cs" Inherits="WebApplication.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/figura.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server">Figura Funko Pop Eren Jaeger 10 cm</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Descripción: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> De la divertida y prestigiosa marca FUNKO, ahora podeís tener toda una gama de "cabezones" y otras figuras de vuestros personajes preferidos relacionados con el cine, la televisión, la música, los dibujos animados, etc. Os traemos las nuevas figuras en formato POP de vinilo con una altura de 10 cm. Funko presenta la figura de 15,24 cm del Colossal Titan de la serie anime Attack On Titan para su colección Vinyl Pop.</asp:Label>
                </li>
                 </ul>
         </div>
         <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 10,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
</asp:Content>

