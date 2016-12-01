<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vistasirope.aspx.cs" Inherits="WebApplication.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/sanz.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server"> Alejandro Sanz - Sirope</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Pistas: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> 
                <ol>1.Un zombie a la intemperie </ol>
                <ol>2.El silencio de tus cuervos</ol>                               
                <ol>3.Tú la necesitas</ol> 
                <ol>4.Un zombie a la intemperie (remix)</ol> 
                <ol>5.La vida que respira</ol>
                <ol>6.Suena la pelota ft Juan Luis Guerra</ol>
                <ol>7.No madura el coco</ol>
                <ol>8.Capitán Tapón</ol>
                <ol>9.Todo huele a ti</ol>
                <ol>10.El club de la verdad</ol>
                <ol>11.A que no me dejas</ol>
                <ol>12.La guarida del calor</ol>
                <ol>13.Pero tú</ol>
                <ol>14.A mí no me importa</ol>
</asp:Label>
                </li>
                 </ul>
        </div>
         <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 15,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>



</asp:Content>

