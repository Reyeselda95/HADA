﻿<%@ Page Title="INARI PLAYS - MUSICA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Musica.aspx.cs" Inherits="WebApplication.Musica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" AllowPaging="True" BackColor="White" CellPadding="1" CellSpacing="1" EnableTheming="True" GridLines="None" HorizontalAlign="Center" ShowHeader="False" ValidateRequestMode="Enabled" Width="800px">
    <Columns>
        <asp:ImageField DataImageUrlField="urlFoto">
        </asp:ImageField>
        <asp:HyperLinkField DataTextField="nombre" />
        <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
    </Columns>
 
        <PagerStyle HorizontalAlign="Center" />
 
    </asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InariDatosConnectionString %>" SelectCommand="SELECT [nombre], [precio], [urlFoto] FROM [musica]"></asp:SqlDataSource>
    
</asp:Content>
