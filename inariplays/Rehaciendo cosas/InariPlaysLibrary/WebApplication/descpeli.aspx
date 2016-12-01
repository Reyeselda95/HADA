<%@ Page Title="INARI PLAYS - DESCRIPCION" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="descpeli.aspx.cs" Inherits="WebApplication.descpeli"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/medio.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server">Los juegos del hambre - Sinsajo - parte 1</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Descripción: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> es la tercera y esperada entrega del fenómeno de gran éxito de taquilla que ha arrasado en las salas de cine de todo el mundo. La historia cobra un nuevo impulso para alcanzar nuevas y emocionantes cotas mientras la crónica futurista de Katniss Everdeen entra en un nuevo mundo. Los juegos han quedado totalmente destruidos para siempre, pero la lucha para sobrevivir está a punto de intensificarse. Katniss tendrá que hacer frente a obstáculos imposibles, observada por una nación llena de esperanza, y hacer uso de todo su coraje y su fuerza contra el todopoderoso Capitolio. Este es el momento en que se da cuenta de que no tiene más opción que extender sus alas y personificar en cuerpo y alma el símbolo del Sinsajo. Aunque sólo sea para salvar a Peeta, deberá convertirse en un líder. Retomamos la historia en el momento en que Katniss acaba de ser rescatada de la destrucción resultante del Vasallaje de los Veinticinco. Despierta en un mundo sorprendente que ni siquiera sabía que existía: los oscuros y profundos subterráneos del Distrito 13, que se suponía que había sido aniquilado. No tarda en descubrir la devastadora realidad que debe afrontar: el Distrito 12 ha quedado reducido a escombros y Peeta está retenido en el Capitolio por el presidente Snow, que trata de manipularlo y hacerle un lavado de cerebro. Al mismo tiempo, Katniss descubre una rebelión secreta que se está extendiendo rápidamente desde el Distrito 13 a todo el resto de Panem, por la que se verá inmersa en un arriesgado plan para piratear el Capitolio y volver las tornas contra el presidente Snow. ExtrasAudio Comentario con el director Francis Lawrence y la productora Nina Jacobson.</asp:Label>
                </li>
          </ul>
            <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 16,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
        </div>
</asp:Content>

