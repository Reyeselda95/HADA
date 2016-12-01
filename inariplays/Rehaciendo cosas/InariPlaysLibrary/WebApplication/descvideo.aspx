<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="descvideo.aspx.cs" Inherits="WebApplication.descvideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/metalmedio.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server">Metal gear solid V - Ground Zeroes</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Descripción: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> Metal Gear Solid V: Ground Zeroes funciona como un prólogo de Metal Gear Solid V: The Phantom Pain y tiene lugar un año después de los acontecimientos de Metal Gear Solid: Peace Walker. Asumiendo el control del legendario Snake (también conocido como Big Boss), los jugadores se encargan de la infiltración en el Campamento Omega, donde están retenidos Paz y Chico. Los rehenes tienen información clave sobre Snake y su organización militar privada, por lo que Snake y su aliado Kaz Miller deben evitar que se divulgue dicha información. Ground Zeroes se centra en el rescate y las posteriores consecuencias que conducen al inicio de The Phantom Pain. Ground Zeroes actúa además como un puente entre anteriores títulos de Metal Gear Solid, facilitando así a los jugadores la entrada al famoso mundo abierto de MGSV. Características: - El poder del Fox Engine: Ground Zeroes nos muestra el impresionante motor gráfico FOX ENGINE de Kojima Productions, un motor de juego que es realmente de nueva generación y que revoluciona completamente la experiencia Metal Gear Solid. - Introducción al nuevo mundo del diseño abierto: Es el primer título de Metal Gear Solid que ofrece una jugabilidad completamente abierta. Ground Zeroes ofrece una libertad total de juego, es el usuario quien decide completamente cómo se llevan a cabo las misiones. - Cautela y sigilo ilimitado: Imagina la clásica jugabilidad de Metal Gear, pero sin restricciones ni límites. Los jugadores pueden usar la inteligencia y la estrategia para colarse y encontrar su camino en las diferentes misiones, o entrar blandiendo todas sus armas. Cada una de las opciones tendrá diferentes efectos en las consecuencias del juego y la posibilidad de avanzar. - Misiones y funciones múltiples: Ground Zeroes cuenta con un modo con historia central y misiones adicionales que van desde la accio´n ta´ctica, a los ataques aéreos y a las fases "encubiertas" que surgirán por sorpresa. </asp:Label>
                </li>
          </ul>
            <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 19,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
        </div>
    <asp:Panel ID="Panel2"  runat="server" style="top:300px;">
        <div id="Div1">
            
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>
