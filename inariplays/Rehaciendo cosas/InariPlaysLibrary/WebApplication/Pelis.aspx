﻿<%@ Page Title="INARI PLAYS - PELICULAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pelis.aspx.cs" Inherits="WebApplication.Pelis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
     <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" AllowPaging="True" BackColor="White" CellPadding="1" CellSpacing="1" EnableTheming="True" GridLines="None" HorizontalAlign="Center" ShowHeader="False" ValidateRequestMode="Enabled" Width="800px">
    <Columns>
        <asp:ImageField DataImageUrlField="urlFoto">
        </asp:ImageField>
        <asp:HyperLinkField DataTextField="nombre" />
        <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
    </Columns>
 
        <PagerStyle HorizontalAlign="Center" />
 
    </asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InariDatosConnectionString %>" SelectCommand="SELECT [precio], [urlFoto], [nombre] FROM [pelicula]"></asp:SqlDataSource>

</asp:Content>
