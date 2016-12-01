<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="descmusic.aspx.cs" Inherits="WebApplication2.descmusic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id = "producto">

    <div id="titulito">
    <asp:GridView ID="GridViewvideo1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="musicaIdMusica" DataSourceID="SqlDataSource1" GridLines="None"
        Height="48px" Width="300px">
        <Columns>
            <asp:BoundField DataField="nombre" ShowHeader="False" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" 
                Font-Names="Cambria" Font-Size="20px" />
            </asp:BoundField>
       </Columns>
    </asp:GridView>
    </div>

    <div id="cosoenmedio">
    <asp:GridView ID="GridViewvideo" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="musicaIdMusica" DataSourceID="SqlDataSource1" GridLines="None"
        Height="157px" Width="900px" >
        <Columns>
            <asp:ImageField DataImageUrlField="urlFoto" ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ImageField>
         </Columns>
         <Columns>
         
            <asp:BoundField DataField="descripcion" ShowHeader="False">
                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
            </asp:BoundField>

         </Columns>
    </asp:GridView>
    </div>

    <div id="abajoprecio">
    <asp:GridView ID="GridViewvideo2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="musicaIdMusica" DataSourceID="SqlDataSource1" GridLines="None"
        Height="28px" Width="300px" >
        <Columns>
            <asp:BoundField DataField="precio" DataFormatString="{0:c}" ShowHeader="False">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="30px" />
             </asp:BoundField>
        </Columns>
    </asp:GridView>
    </div>

    <div id ="comprar">
        <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT * FROM [musica] WHERE ([musicaIdMusica] = @musicaIdMusica)">
        <SelectParameters>
            <asp:QueryStringParameter Name="musicaIdMusica" QueryStringField="id" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>
