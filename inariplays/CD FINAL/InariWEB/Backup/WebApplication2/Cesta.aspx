<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cesta.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="WebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="listapelis">

        
    <asp:Table ID="Table1" runat="server" Width="969px">
       <asp:TableFooterRow>
           <asp:TableHeaderCell>Imagen</asp:TableHeaderCell>
           <asp:TableHeaderCell>Producto</asp:TableHeaderCell>
           <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
           <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
       </asp:TableFooterRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Image ID="Image1" runat="server" ImageUrl="Images/sinsajo.png"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/descpeli.aspx">Los juegos del hambre - Sinsajo - parte 1</asp:HyperLink> 
            </asp:TableCell>
            <asp:TableCell>
                <div></div><asp:Label ID="precio1" runat="server" Text="Label"> 16,99 € </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="cantnum1" runat="server" Text="Label"> 2 ud. </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableHeaderRow>
            <asp:TableCell>
                 <asp:Image ID="niños" runat="server" ImageUrl="Images/niños.png"/>
            </asp:TableCell>
            <asp:TableCell>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/descpeli2.aspx">Niños Grandes</asp:HyperLink> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="precio2" runat="server" Text="Label"> 9,99 € </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="cantnum2" runat="server" Text="Label"> 1 ud. </asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
        
    </asp:Table>
        <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Comprar</asp:LinkButton>
         </div>
    </div>

</asp:Content>

