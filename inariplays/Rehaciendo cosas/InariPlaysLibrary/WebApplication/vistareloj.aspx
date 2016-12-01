<%@ Page Title="INARI PLAYS - RELOJ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vistareloj.aspx.cs" Inherits="WebApplication.vistareloj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="descrip" style="height:500px">
     <div class="imagenpeli">
                <asp:Image ID="mercha" runat="server" ImageUrl="Images/oscuro.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server" >Star Wars: Reloj despertador Darth Vader</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server" >Descripción: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server" >Darth Vader despertador te ayuda a comenzar el día con fuerza con la mismísima respiración del más malvado entre los malos de película: el fantástico Reloj Despertador Darth Vader proyecta la hora hacia la pared.﻿</asp:Label>
                </li>
                 </ul>

        </div>
         <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 16,99€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>
