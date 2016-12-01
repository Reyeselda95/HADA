<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="descpeli2.aspx.cs" Inherits="WebApplication.descpeli2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/niñosmedio.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server">Niños Grandes</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Descripción: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> ¡No porque te hagas mayor tienes que envejecer! Adam Sandler, Kevin James, Chris Rock, David Spade y Rob Schneider, las superestrellas de la comedia, están en su mejor momento al encarnar a unos amigos de la infancia que se reúnen un fin de semana para revivir los viejos tiempos. Poco importa que estos cinco hombres sean hombres de negocios, esposos o padres respetables. Cuando se juntan, nada impide que estos niños grandes se lo pasen bomba. Los creadores de ‘CLICK’ te presentan una película divertidísima y entrañable que demuestra que los hombres son como niños.</asp:Label>
                </li>
                 </ul>
            <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 9,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>
