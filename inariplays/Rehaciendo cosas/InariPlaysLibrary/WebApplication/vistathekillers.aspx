<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vistathekillers.aspx.cs" Inherits="WebApplication.vistathekillers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/killers.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server"> The Killers - Battle Born</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Pistas: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> 
                <ol>1.Flesh And Bone</ol>
                <ol>2.Runaways</ol>                               
                <ol>3.The Way It Was</ol> 
                <ol>4.Here With Me</ol> 
                <ol>5.A Matter Of Time</ol>
                <ol>6.Suena la pelota ft Juan Luis Guerra</ol>
                <ol>7.Miss Atomic Bomb</ol>
                <ol>8.The Rising Tide</ol>
                <ol>9.Heart Of A Girl</ol>
                <ol>10.From Here On Out</ol>
                <ol>11.Be Still</ol>
                <ol>12.Battle Born</ol>
                <ol>[edicion deluxe]</ol>
                <ol>13.Carry Me Home</ol>
                <ol>14.Flesh And Bone (Jacques Lu Cont Remix)</ol>
                <ol>15.Prize Fighter</ol>
</asp:Label>
                </li>
                 </ul>
        </div>
         <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 11,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
</asp:Content>

