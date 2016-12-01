<%@ Page Title="INARI PLAYS - MERCHANDISING" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Merchan.aspx.cs" Inherits="WebApplication.Merchan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AllowPaging="True" BackColor="White" CellPadding="1" CellSpacing="1" EnableTheming="True" GridLines="None" ShowHeader="False" ValidateRequestMode="Enabled" Width="800px" DataKeyNames="merchandisingIdMerchandising">
 
        <Columns>
            <asp:ImageField DataImageUrlField="urlFoto">
            </asp:ImageField>
            <asp:HyperLinkField DataNavigateUrlFields="merchandisingIdMerchandising" DataNavigateUrlFormatString="~/descmerchan.aspx?id={0}" DataTextField="nombre" />
            <asp:BoundField DataField="precio" SortExpression="precio" DataFormatString="{0:c}" />
        </Columns>
 
        <PagerStyle HorizontalAlign="Center" />
 
    </asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT * FROM [merchandising]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
  
</asp:Content>

