<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Videojuegos.aspx.cs" Inherits="WebApplication.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">



    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" BackColor="White" CellPadding="1" CellSpacing="1" EnableTheming="True" GridLines="None" HorizontalAlign="Center" ShowHeader="False" ValidateRequestMode="Enabled" Width="800px">
    <Columns>
        <asp:ImageField DataImageUrlField="urlFoto">
        </asp:ImageField>
        <asp:HyperLinkField DataTextField="nombre" DataNavigateUrlFields="nombre" DataNavigateUrlFormatString="~/descvideo.aspx?nombre={0}" />
        <asp:BoundField DataField="precio" SortExpression="precio" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InariDatosConnectionString %>" SelectCommand="SELECT * FROM [Videojuego]"></asp:SqlDataSource>
</asp:Content>
